import { Injectable } from '@angular/core';
import * as Msal from 'msal';
import { config } from 'src/app/views/pages/authentication/config/config';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  public  msalInstance = new Msal.UserAgentApplication(config)
  
  constructor() { }

  public login = () => {
    this.msalInstance.loginPopup({
      scopes: ['api://3eea5a6b-cc13-4f0e-b797-b32dfade784a/user_impersonation']
    })
  }

  public logout = () => {
    this.msalInstance.logout();
  }

  public getAccessToken = (): Promise<string | undefined> => {
    const request = {
      scopes: ['User.Read', 'User.ReadBasic.All']
    };
    return this.msalInstance.acquireTokenSilent({scopes: ['api://3eea5a6b-cc13-4f0e-b797-b32dfade784a/user_impersonation']}).then((response) => {
      console.log(response)
      return response.accessToken;
    }).catch((error) => {
      console.error('Error acquiring token:', error);
      return undefined;
    });
  }

}
