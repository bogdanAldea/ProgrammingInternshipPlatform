import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { InternshipRequest } from '../contracts/requests/InternshipRequest';
import { FullInternshipResponse } from '../contracts/responses/FullInternshipResponse';
import { Observable } from 'rxjs';
import { ApiRoutes } from '../../configurations/api-routes';

@Injectable({
  providedIn: 'root'
})
export class InternshipService {

  constructor(private httpClient: HttpClient) { }

  public addNewInternship = (request: InternshipRequest): Observable<FullInternshipResponse> => {
    const url = ApiRoutes.Internships.Base;
    return this.httpClient.post<FullInternshipResponse>(url, request);
  }
}
