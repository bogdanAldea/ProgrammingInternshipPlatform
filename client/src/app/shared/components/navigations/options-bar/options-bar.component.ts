import { Component, Input } from '@angular/core';
import { Node } from '../link-node/link-node.component';

@Component({
  selector: 'options-bar',
  templateUrl: './options-bar.component.html',
  styleUrls: ['./options-bar.component.scss']
})
export class OptionsBar {
  @Input() options: ReadonlyArray<Node> | undefined;
}
