import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AccountWithRoles } from '../../contracts/account-with-roles';
import { Observable } from 'rxjs';
import { Account } from '../../contracts/account';
import { ApiRoutes } from 'src/app/core/configurations/api-routes';
import { Role } from '../../contracts/role';
import { MemberAccountRegistration } from '../../contracts/member-account-registration';
import { SignupRequest } from 'src/app/core/authentication/contracts/signup-request';
import { SigninRequest } from 'src/app/core/authentication/contracts/signin-request';
import { TokenResponse } from 'src/app/core/authentication/contracts/token-response';

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

  public getAllAccountsAtOrganisation = () : Observable<AccountWithRoles[]> => {
    const url: string = ApiRoutes.Account.Base;
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

  public addNewUserAccount = (account: MemberAccountRegistration): Observable<Account> => {
    const url: string = ApiRoutes.Account.Base;
    return this.httpClient.post<Account>(url, account);
  }

  public signup = (request: SignupRequest): Observable<Account> => {
    const url: string = ApiRoutes.Account.Signup;
    return this.httpClient.post<Account>(url, request);
  }

  public signin = (request: SigninRequest): Observable<TokenResponse> => {
    const url: string = ApiRoutes.Account.Signin;
    return this.httpClient.post<TokenResponse>(url, request);
  }
}
