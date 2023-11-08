import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { HttpParamsBuilder } from 'src/app/shared/helpers/requests/httpParamsBuilder';
import { InternshipQueryParams } from './internshipQueryParams';
import { Pagination } from 'src/app/shared/services/types';
import { Internship, InternshipServerResponse } from '../models/internship';

@Injectable({
  providedIn: 'root'
})
export class InternshipService {
  private readonly baseUrl: string = 'https://localhost:44308/api/Internships';
  private readonly paramBuilder: HttpParamsBuilder = new HttpParamsBuilder();

  public constructor(private readonly httpClient: HttpClient) { }

  public getAllInternshipPrograms = (params: InternshipQueryParams): Observable<Pagination<Internship>> => {
    const queryParams: HttpParams = this.paramBuilder
      .page(params.page)
      .resultsPerPage(params.resultsPerPage)
      .submit('estimatedGraduationDate', params.estimatedGraduationDate)
      .submit('scheduledStartDate', params.scheduledStartDate)
      .submit('internshipStatus', params.internshipStatus)
      .build();
    return this.httpClient.get<Pagination<InternshipServerResponse>>(this.baseUrl, {params: queryParams})
    .pipe(map((response: Pagination<InternshipServerResponse>) => {
      return {
        totalItems: response.totalItems,
        currentPage: response.currentPage,
        totalPages: response.totalPages,
        results: response.results.map(internship => new Internship(internship))
      }
    }));
  }
}
