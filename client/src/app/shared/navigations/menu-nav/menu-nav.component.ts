import { Component } from '@angular/core';
import { MenuLink } from '../../layouts/configurations/menu-link';
import { ApplicationMenus } from '../../layouts/configurations/app-menus';

@Component({
  selector: 'app-menu-nav',
  templateUrl: './menu-nav.component.html',
  styleUrls: ['./menu-nav.component.scss']
})
export class MenuNavComponent {
  public menu: MenuLink[] = [];

  public constructor() {
    this.menu = ApplicationMenus.administration;
  }
}
