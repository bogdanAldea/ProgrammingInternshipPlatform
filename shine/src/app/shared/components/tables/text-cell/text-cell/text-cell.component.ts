import { Component, Input } from '@angular/core';

@Component({
  selector: 'text-cell',
  templateUrl: './text-cell.component.html',
  styleUrls: ['./text-cell.component.scss']
})
export class TextCell {
  @Input() data: any;
  @Input() icon?: string;
}
