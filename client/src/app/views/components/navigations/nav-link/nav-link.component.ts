import { Component, Input } from '@angular/core';
import { MenuItem } from 'src/app/views/application-configs/app-menu/MenuItem';

@Component({
  selector: 'app-nav-link',
  templateUrl: './nav-link.component.html',
  styleUrls: ['./nav-link.component.scss']
})
export class NavLinkComponent {
  @Input() menuItem!: MenuItem
  @Input() color: string = 'white'
}
