import { Token } from '@angular/compiler';
import { Injectable } from '@angular/core';
import * as Msal from 'msal';
import { config } from 'src/app/features/authentication/config/config';
import { ApplicationToken } from '../response/ApplicationToken';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  public  msalInstance = new Msal.UserAgentApplication(config)
  
  constructor() { }

  public login = () => {
    this.msalInstance.loginRedirect({
      scopes: ['openid', 'profile', 'user.read']
    })
  }

  public logout = () => {
    this.msalInstance.logout();
  }

  public getAccessToken = (): Promise<ApplicationToken | undefined> => {
    const account = this.msalInstance.getAccount();
    if (!account) {
      // If the user is not logged in, you can redirect to the login page
      this.login();
      return Promise.reject('User login is required.');
    }

    return this.msalInstance.acquireTokenSilent({
      scopes: ['openid', 'profile', 'user.read'],
      account: account
    }).then((response) => {
      const token = new ApplicationToken(response.accessToken, response.idToken);
      return token;
    }).catch((error) => {
      console.error('Error acquiring token:', error);
      return undefined;
    });
  }

  // public handleRedirectCallback = (): Promise<Msal.AuthResponse> => {
  //   return this.msalInstance.handleRedirectCallback((error, response) => {
  //     if (error) {
  //       console.error('Authentication error:', error);
  //     } else if (response) {
  //       // The tokens are available in response.idToken and response.accessToken
  //       console.log('ID Token:', response.idToken);
  //       console.log('Access Token:', response.accessToken);
  //     }
  //   });
  // }
}
