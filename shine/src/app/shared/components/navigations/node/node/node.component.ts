import { Component, Input } from '@angular/core';
import { NodeData } from '../types/nodeData';

@Component({
  selector: 'node',
  templateUrl: './node.component.html',
  styleUrls: ['./node.component.scss']
})
export class Node {
  @Input() nodeData!: NodeData;
  @Input() colour: string = 'white';
}
