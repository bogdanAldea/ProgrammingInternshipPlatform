import { Injectable } from '@angular/core';
import * as Msal from 'msal';
import { config } from '../config/authentication.config';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private msalInstance = new Msal.UserAgentApplication(config);
  private scopes: string[] = ['api://3eea5a6b-cc13-4f0e-b797-b32dfade784a/user_impersonation'];

  public login = (): Promise<string | undefined> => {
    return this.msalInstance.loginPopup({
      scopes: this.scopes
    }).then(() => this.getAccessToken().then(token => {return token}))
  }

  public logout = () => {
    this.msalInstance.logout();
  }

  public getAccessToken = (): Promise<string | undefined> => {
    return this.msalInstance.acquireTokenSilent({scopes: this.scopes}).then((response) => {
      return response.accessToken;
    }).catch((error) => {
      console.error('Error acquiring token:', error);
      return undefined;
    });
  }

  constructor() { }
}
