import { Component } from '@angular/core';
import { Node } from '../../navigations/link-node/link-node.component';
import { MenuNodes } from 'src/app/shared/configurations/menuNodes';

@Component({
  selector: 'private-layout',
  templateUrl: './private-layout.component.html',
  styleUrls: ['./private-layout.component.scss']
})
export class PrivateLayout {
  public nodes: ReadonlyArray<Node> = MenuNodes.ForAdministrator;
}
