import { Component } from '@angular/core';
import { MenuItem } from 'src/app/configurations/navigation-meniu/menu-item';
import { Menus } from 'src/app/configurations/navigation-meniu/navigation-menus';


@Component({
  selector: 'app-stacked-navigation',
  templateUrl: './stacked-navigation.component.html',
  styleUrls: ['./stacked-navigation.component.scss']
})
export class StackedNavigationComponent {
  public menu: MenuItem[] = [];

  public constructor() {
    this.menu = Menus.administratorMenuItems;
  }
}
