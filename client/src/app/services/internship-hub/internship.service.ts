import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { IInternshipService } from 'src/app/application/internship-hub/service/IInternshipService';
import { PartialInternship, PartialInternshipResponse } from 'src/app/domain/internship-hub/internships/PartialInternship';

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
}
