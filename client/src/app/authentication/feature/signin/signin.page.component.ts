import { Component } from '@angular/core';
import { AuthenticationService } from '../../services/authentication.service';

@Component({
  selector: 'signin.page',
  templateUrl: './signin.page.component.html',
  styleUrls: ['./signin.page.component.scss']
})
export class SigninPage {
  public isUserLoggedIn: boolean = false;

  public constructor(private authenticationService: AuthenticationService) {}

  public login = () => this.authenticationService.login()
    .then(token => {
      if (token !== undefined)
       this.saveToken(token)
    });

  private saveToken = (token: string) => localStorage.setItem('access_token', token)
}
