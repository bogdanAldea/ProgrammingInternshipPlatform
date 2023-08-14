import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'src/app/application-configs/app-menu/MenuItem';
import { Menus } from 'src/app/application-configs/app-menu/Menus';
import { ApplicationToken } from 'src/app/core/authentication/response/ApplicationToken';
import { AuthenticationService } from 'src/app/core/authentication/service/authentication.service';


@Component({
  selector: 'app-navigation-layout',
  templateUrl: './navigation-layout.component.html',
  styleUrls: ['./navigation-layout.component.scss']
})
export class NavigationLayoutComponent {
  public menu: MenuItem[] = Menus.Administrator;

  public constructor(private authService: AuthenticationService) {
    this.authService.getAccessToken()
    .then((token?: ApplicationToken) => {
      if (token) {
        localStorage.setItem('access_token', token.accessToken.toString());
        localStorage.setItem('id_token', token.idToken.toString())
      }
    })
    .catch((error) => {
      console.error('Error acquiring token:', error);
    });
  }
}
