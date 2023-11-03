import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { InternshipWithCoordinator, InternshipWithCoordinatorServerResponse } from '../models/internshipWitCoordinator';
import { InternshipQueryParams } from '../models/queryParams';
import { HttpParamsBuilder } from 'src/app/shared/helpers/requests/httpParamsBuilder';

@Injectable({
  providedIn: 'root'
})
export class InternshipHubService {
  private readonly baseUrl = 'https://localhost:44308/api/Internships'
  private queryParamsBuider = new HttpParamsBuilder();
  
  public constructor(private readonly httpClient: HttpClient) { }

  public getAllInternshipProgramsAtOrganisation = (params: InternshipQueryParams): Observable<ReadonlyArray<InternshipWithCoordinator>> => {
    let queryParams: HttpParams = this.queryParamsBuider
      .page(params.page)
      .resultsPerPage(params.resultsPerPage)
      .submit('internshipStatus', params.internshipStatus)
      .submit('scheduledStartDate', params.scheduledStartDate?.toDateString())
      .submit('estimatedGraduationDate', params.estimatedGraduationDate?.toDateString())
      .build();

      return this.httpClient.get<any>(this.baseUrl, {params: queryParams})
        .pipe(map((response: any) => {
          console.log(response)
          return response.results.map((response: InternshipWithCoordinatorServerResponse) => new InternshipWithCoordinator(response))
      }))

  }
}
