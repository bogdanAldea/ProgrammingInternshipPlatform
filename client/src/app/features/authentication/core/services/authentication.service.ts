import { Injectable } from '@angular/core';
import { SignupRequest } from '../interfaces/signup-request';
import { SigninRequest } from '../interfaces/signin-request';
import { SigninResponse } from '../interfaces/signin-response';
import { HttpClient } from '@angular/common/http';
import { ApiRoutes } from 'src/app/configurations/api-routes/api-routes';
import { AdminRole } from '../interfaces/admin-role';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  public authenticationUrl: string = "https://localhost:7049/api/UserAccounts"
  public constructor(private httpClient: HttpClient) { }

  public submitSignUpRequest = (request: SignupRequest) => {
    const registrationUrl: string = `${this.authenticationUrl}/registration`;
    return this.httpClient.post(registrationUrl, request);
  }

  public submitSignInRequest = (request: SigninRequest) => {
    const signInUrl: string = `${this.authenticationUrl}/login`;
    return this.httpClient.post<SigninResponse>(signInUrl, request);
  }

  public saveToken = (token: string) => {
    localStorage.setItem('access_token', token);
  }

  public getAdminRole = () => {
    const url = ApiRoutes.Roles.AdminRole;
    return this.httpClient.get<AdminRole>(url);
  }
}
