import { Component, INJECTOR, Inject, OnDestroy, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/core/authentication/service/authentication.service';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.scss']
})
export class SigninComponent {
  public isUserLoggedIn: boolean = false;
  
  public constructor(private authenticationService: AuthenticationService) {}

  public login = () => {
    this.authenticationService.login();
  }
  
}
