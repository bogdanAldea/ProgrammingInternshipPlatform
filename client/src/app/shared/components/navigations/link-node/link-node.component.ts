import { Component, Input } from '@angular/core';

@Component({
  selector: 'link-node',
  templateUrl: './link-node.component.html',
  styleUrls: ['./link-node.component.scss']
})
export class LinkNode {
  @Input() node!: Node;
  @Input() colour: string = 'white';
}

export interface Node {
  label?: string;
  icon?: string;
  route: string;
}