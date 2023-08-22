import { Component } from '@angular/core';
import { MenuItem } from 'src/app/views/application-configs/app-menu/MenuItem';
import { Menus } from 'src/app/views/application-configs/app-menu/Menus';


@Component({
  selector: 'app-navigation-layout',
  templateUrl: './navigation-layout.component.html',
  styleUrls: ['./navigation-layout.component.scss']
})
export class NavigationLayoutComponent {
  public menu: MenuItem[] = Menus.Administrator;
}
