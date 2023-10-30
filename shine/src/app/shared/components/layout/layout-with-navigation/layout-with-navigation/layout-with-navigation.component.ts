import { Component } from '@angular/core';
import { NodeData } from '../../../navigations/node/types/nodeData';
import { MenuNodeConfiguration } from 'src/app/shared/configurations/menu-nodes/menuNodeConfiguration';

@Component({
  selector: 'layout-with-navigation',
  templateUrl: './layout-with-navigation.component.html',
  styleUrls: ['./layout-with-navigation.component.scss']
})
export class LayoutWithNavigation {
  public menuNodes: NodeData[] = MenuNodeConfiguration.getMenu();
}
