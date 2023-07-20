import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AccountWithRoles } from '../../contracts/account-with-roles';
import { Observable } from 'rxjs';
import { Account } from '../../contracts/account';
import { ApiRoutes } from 'src/app/core/configurations/api-routes';
import { Role } from '../../contracts/role';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  public constructor(private httpClient: HttpClient) { }

  public getUserAccount = (userAccountId: string) : Observable<AccountWithRoles> => {
    const base: string = ApiRoutes.Account.Base;
    const url: string = `${base}/${userAccountId}`;
    return this.httpClient.get<AccountWithRoles>(url);
  }

  public getAllAccountsAtOrganisation = (organisationId: string) : Observable<AccountWithRoles[]> => {
    const base: string = ApiRoutes.Organisation.Base;
    const endpoint: string = ApiRoutes.Organisation.AllAccounts;
    const url: string = `${base}/${organisationId}/${endpoint}`;
    return this.httpClient.get<AccountWithRoles[]>(url);
  }

  public assignRolesToUserAccount = (userId: string, roles: Role[]): Observable<void> => {
    const url: string = `${ApiRoutes.Account.Base}/${userId}/roles/add`;
    return this.httpClient.post<void>(url, roles);
  }

  public removeRolesFromUserAccount = (userId: string, roles: Role[]): Observable<void> => {
    const url: string = `${ApiRoutes.Account.Base}/${userId}/roles/remove`;
    return this.httpClient.post<void>(url, roles);
  }
}
