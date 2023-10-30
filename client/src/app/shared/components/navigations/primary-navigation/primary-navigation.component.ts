import { Component, Input } from '@angular/core';
import { Node } from '../link-node/link-node.component';

@Component({
  selector: 'primary-navigation',
  templateUrl: './primary-navigation.component.html',
  styleUrls: ['./primary-navigation.component.scss']
})
export class PrimaryNavigation {
  @Input() nodes!: ReadonlyArray<Node>;

  public accountControls: ReadonlyArray<Node> = [
    {
      icon: '../../../../../assets/icons/light/Global/Notification.svg',
      route: ''
    },
    {
      icon: '../../../../../assets/icons/light/Global/Settings.svg',
      route: ''
    }
  ]
}
