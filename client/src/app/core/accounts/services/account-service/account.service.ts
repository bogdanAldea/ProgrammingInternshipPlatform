import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AccountWithRoles } from '../../contracts/account-with-roles';
import { Observable } from 'rxjs';
import { Account } from '../../contracts/account';
import { ApiRoutes } from 'src/app/core/configurations/api-routes';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  public constructor(private httpClient: HttpClient) { }

  public getUserAccount = (userAccountId: string) : Observable<Account> => {
    const base: string = ApiRoutes.Account.Base;
    const url: string = `${base}/${userAccountId}`;
    return this.httpClient.get<Account>(url);
  }

  public getAllAccountsAtOrganisation = (organisationId: string) : Observable<AccountWithRoles[]> => {
    const base: string = ApiRoutes.Organisation.Base;
    const endpoint: string = ApiRoutes.Organisation.AllAccounts;
    const url: string = `${base}/${organisationId}/${endpoint}`;
    return this.httpClient.get<AccountWithRoles[]>(url);
  }
}
