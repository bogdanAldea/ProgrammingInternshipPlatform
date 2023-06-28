import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { InternshipResponse } from '../interfaces/internship-response';
import { Internship } from '../models/internship';
import { ApiBaseUrls } from 'src/configurations/apiRoutes';

@Injectable({
  providedIn: 'root'
})
export class InternshipManagementService 
{
  private baseOrganisationsApi: string = ApiBaseUrls.Organisations;
  private apiUrl = `${this.baseOrganisationsApi}/B4F75FED-37BF-40FC-A8B3-F071B41A3FC1/internships`

  constructor(private httpClient: HttpClient) { }

  public getAllInternshipsAtOrganisation = () : Observable<Internship[]> => {
    return this.httpClient.get<InternshipResponse[]>(this.apiUrl).pipe(map((response: InternshipResponse[]) => {
        return response.map((internship: InternshipResponse) => new Internship(internship));
      })
    );
  };

}
