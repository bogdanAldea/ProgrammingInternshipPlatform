import { Component } from '@angular/core';
import { NodeData } from '../shared/components/navigations/node/types/nodeData';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  public title = 'client';
  public menuItems: NodeData[] = [
    {
      label: 'Overview',
      icon: '../../assets/icons/light/Actions/Add.svg',
      route: ''
    },
    {
      label: 'Overview',
      icon: '../../assets/icons/light/Actions/Add.svg',
      route: ''
    },
    {
      label: 'Overview',
      icon: '../../assets/icons/light/Actions/Add.svg',
      route: ''
    }
  ]
}
