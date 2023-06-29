import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SignupRequest } from '../interfaces/signup-request';
import { ApiBaseUrls } from 'src/configurations/apiRoutes';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  public signUpUrl: string = ApiBaseUrls.Accounts
  public constructor(private httpClient: HttpClient) { }

  public submitSignUpRequest = (request: SignupRequest) => {
    const registrationUrl: string = `${this.signUpUrl}/registration`
    return this.httpClient.post(registrationUrl, request);
  }
}
