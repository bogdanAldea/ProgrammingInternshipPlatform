import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { Internship } from '../models/internship';
import { InternshipResponse } from '../interfaces/internship-response';

@Injectable({
  providedIn: 'root'
})
export class InternshipServiceService {
  private apiUrl: string = "https://localhost:7049/api"
  
  public constructor(private httpClient: HttpClient) { }

  public getAllInternshipsAtOrganisation = () : Observable<Internship[]> => {
    const url = `${this.apiUrl}/organisations/B4F75FED-37BF-40FC-A8B3-F071B41A3FC1/internships`
    return this.httpClient.get<InternshipResponse[]>(url).pipe(map((response: InternshipResponse[]) => {
        return response.map((internship: InternshipResponse) => new Internship(internship));
      })
    );
  };
}
