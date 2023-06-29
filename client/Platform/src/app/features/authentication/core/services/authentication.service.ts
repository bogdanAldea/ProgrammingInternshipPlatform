import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SignupRequest } from '../interfaces/signup-request';
import { ApiBaseUrls } from 'src/configurations/apiRoutes';
import { SigninRequest } from '../interfaces/signin-request';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  public signUpUrl: string = ApiBaseUrls.Accounts
  public constructor(private httpClient: HttpClient) { }

  public submitSignUpRequest = (request: SignupRequest) => {
    const registrationUrl: string = `${this.signUpUrl}/registration`;
    return this.httpClient.post(registrationUrl, request);
  }

  public submitSignInRequest = (request: SigninRequest) => {
    const signInUrl: string = `${this.signUpUrl}/login`;
    return this.httpClient.post(signInUrl, request);
  }
}
