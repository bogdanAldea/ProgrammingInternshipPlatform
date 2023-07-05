import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AccountResponse } from '../interfaces/account-response';
import { ApiRoutes } from 'src/app/configurations/api-routes/api-routes';
import { AccountWithRoles } from '../interfaces/account-with-roles';

@Injectable({
  providedIn: 'root'
})
export class AccountsService {

  public constructor(private httpClient: HttpClient) { }

  public getAllAccountsAtOrganisation = (organisationId: string) : Observable<AccountWithRoles[]> => {
    const apiUrl: string = ApiRoutes.Organisation.Base;
    const endpoint: string = ApiRoutes.Organisation.AllAccounts;
    return this.httpClient.get<AccountWithRoles[]>(`${apiUrl}/${organisationId}/${endpoint}`);
  }
}
