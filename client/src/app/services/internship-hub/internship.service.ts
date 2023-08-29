import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { IInternshipService } from 'src/app/application/service/IInternshipService';
import { InternshipSetupRequest } from 'src/app/domain/internship-hub/internships/InternshipSetupRequest';
import { PartialInternship, PartialInternshipResponse } from 'src/app/domain/internship-hub/internships/PartialInternship';
import { TrainerDelegateRequest } from 'src/app/domain/internship-hub/internships/TrainerDelegateRequest';

@Injectable({
  providedIn: 'root'
})
export class InternshipService implements IInternshipService {
  private readonly apiUrl: string = 'https://localhost:44308/api/Internships';

  constructor(private httpClient: HttpClient) { }

  public getAllInternshipPrograms = (): Observable<PartialInternship[]> => {
    return this.httpClient.get<PartialInternshipResponse[]>(this.apiUrl)
      .pipe(map((response: PartialInternshipResponse[]) => {
        return response.map((response: PartialInternshipResponse) => new PartialInternship(response));
      }))
  }

  public createInternshipSetup = (request: InternshipSetupRequest): Observable<string> => {
    return this.httpClient.post(this.apiUrl, request, {responseType: 'text'})
  }

  public delegateTrainer = (internshipId: string, request: TrainerDelegateRequest): Observable<any> => {
    return this.httpClient.patch(`${this.apiUrl}/${internshipId}`, request, { responseType: 'json' })
  }
}
