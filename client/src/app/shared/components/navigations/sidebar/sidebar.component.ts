import { Component, Input } from '@angular/core';
import { Node } from '../link-node/link-node.component';

@Component({
  selector: 'sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class Sidebar {
  @Input() nodes: ReadonlyArray<Node> | undefined;
}
