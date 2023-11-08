import { Component, Input } from '@angular/core';
import { RouteNode } from 'src/app/shared/helpers/routing/node';

@Component({
  selector: 's-optionbar',
  templateUrl: './optionbar.component.html',
  styleUrls: ['./optionbar.component.scss']
})
export class Optionbar {
  @Input() options: ReadonlyArray<RouteNode> = [];
}
