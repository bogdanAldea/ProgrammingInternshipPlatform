import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'src/app/application-configs/app-menu/MenuItem';
import { Menus } from 'src/app/application-configs/app-menu/Menus';
import { ApplicationToken } from 'src/core/authentication/response/ApplicationToken';
import { AuthenticationService } from 'src/core/authentication/service/authentication.service';

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
      console.log('Access Token:', token);
    })
    .catch((error) => {
      console.error('Error acquiring token:', error);
    });
  }

  public logout = () => {
    this.authService.logout();
  }
}
