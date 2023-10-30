import { Component, Input } from '@angular/core';
import { NodeData } from '../../node/types/nodeData';

@Component({
  selector: 'settings-navbar',
  templateUrl: './settings-navbar.component.html',
  styleUrls: ['./settings-navbar.component.scss']
})
export class SettingsNavbar {
  @Input() menuItems!: NodeData[];
}
