import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiRoutes } from '../../configurations/api-routes';
import { FullInternship } from '../../internship-management/models/enums/FullInternship';
import { Observable, map } from 'rxjs';
import { FullInternshipResponse } from '../../internship-management/contracts/responses/FullInternshipResponse';

@Injectable({
  providedIn: 'root'
})
export class OrganisationService {

  public constructor(private httpClient: HttpClient) { }

  public getAllInternshipsAtOrganisation = (organisationId: string): Observable<FullInternship[]> => {
    const url: string = `${ApiRoutes.Organisation.Base}/${organisationId}/internships`;
    return this.httpClient.get<FullInternshipResponse[]>(url).pipe(
      map((response: FullInternshipResponse[]) => {
        return response.map((internship: FullInternshipResponse) => new FullInternship(internship));
      })
    );
  }
}
