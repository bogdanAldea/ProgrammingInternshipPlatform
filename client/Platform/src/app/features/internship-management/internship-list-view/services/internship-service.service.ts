import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { InternshipDetailResponse } from '../contracts/responses/internship-details/internship-detail-response';
import { InternshipDetails } from '../models/internship-details/internship-details';
import { Observable, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InternshipService {
  private apiUrl: string = "https://localhost:7049/api/Organisations/F062E40D-073E-47B0-8454-DF87F1AF3362/internships?id=F062E40D-073E-47B0-8454-DF87F1AF3362";

  constructor(private httpClient: HttpClient) { }

  public getAllInternshipsAtOrganisation = () : Observable<InternshipDetails[]> => {
    return this.httpClient.get<InternshipDetailResponse[]>(this.apiUrl).pipe(map((response: InternshipDetailResponse[]) => {
        return response.map((internship: InternshipDetailResponse) => new InternshipDetails(internship));
      })
    );
  };
}
