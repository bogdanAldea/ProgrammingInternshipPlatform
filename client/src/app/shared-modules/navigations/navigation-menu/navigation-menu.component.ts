import { Component, Input } from '@angular/core';
import { MenuItem } from 'src/app/application-configs/app-menu/MenuItem';

@Component({
  selector: 'app-navigation-menu',
  templateUrl: './navigation-menu.component.html',
  styleUrls: ['./navigation-menu.component.scss']
})
export class NavigationMenuComponent {
  @Input() menu: MenuItem[] | undefined;
}
