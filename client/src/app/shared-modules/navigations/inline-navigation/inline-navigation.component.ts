import { Component, Input } from '@angular/core';
import { MenuItem } from 'src/app/application-configs/app-menu/MenuItem';

@Component({
  selector: 'app-inline-navigation',
  templateUrl: './inline-navigation.component.html',
  styleUrls: ['./inline-navigation.component.scss']
})
export class InlineNavigationComponent {
  @Input() menu: MenuItem[] | undefined;
}
