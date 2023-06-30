// Mentorship Task

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SignupRequest } from '../interfaces/signup-request';
import { ApiBaseUrls } from 'src/configurations/apiRoutes';
import { SigninRequest } from '../interfaces/signin-request';
import { SigninResponse } from '../interfaces/sign-in-response';

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
    return this.httpClient.post<SigninResponse>(signInUrl, request);
  }

  public saveToken = (token: string) => {
    localStorage.setItem('access_token', token);
  }
}
