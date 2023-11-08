import { Component } from '@angular/core';
import { AuthenticationService } from '../../data-access/authentication.service';

@Component({
  selector: 's-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.scss']
})
export class Signin {

  public constructor(private readonly service: AuthenticationService) {}

  public login = () => this.service.login()
    .then(token => {
      if (token !== undefined)
       this.saveToken(token)
    });

  private saveToken = (token: string) => localStorage.setItem('access_token', token)
}
