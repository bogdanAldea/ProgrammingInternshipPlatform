import { Component } from '@angular/core';
import { Menus } from 'src/app/application-configs/app-menu/Menus';

@Component({
  selector: 'app-settings-navigation',
  templateUrl: './settings-navigation.component.html',
  styleUrls: ['./settings-navigation.component.scss']
})
export class SettingsNavigationComponent {
  public settings = Menus.InternshipSettings;
}
