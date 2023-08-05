import { Component } from '@angular/core';
import { AuthenticationService } from 'src/app/core/authentication/service/authentication.service';

@Component({
  selector: 'app-user-controls-navigation',
  templateUrl: './user-controls-navigation.component.html',
  styleUrls: ['./user-controls-navigation.component.scss']
})
export class UserControlsNavigationComponent {

  public constructor(private authenticationService: AuthenticationService) {}

  public logout = () => {
    this.authenticationService.logout();
  }

}
