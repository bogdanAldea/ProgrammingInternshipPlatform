import { Component, Input } from '@angular/core';
import { NodeData } from '../../node/types/nodeData';

@Component({
  selector: 'inline-navbar',
  templateUrl: './inline-navbar.component.html',
  styleUrls: ['./inline-navbar.component.scss']
})
export class InlineNavbar {
  @Input() menuItems!: NodeData[];
  public accountControls: NodeData[] = [
    {
      icon: '../../../../../../assets/icons/light/Global/Notification.svg',
      route: ''
    },
    {
      icon: '../../../../../../assets/icons/light/Global/Settings.svg',
      route: ''
    }
  ]
}
