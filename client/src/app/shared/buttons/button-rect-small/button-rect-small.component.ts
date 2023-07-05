import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-button-rect-small',
  templateUrl: './button-rect-small.component.html',
  styleUrls: ['./button-rect-small.component.scss']
})
export class ButtonRectSmallComponent {
 @Input() actionName: string = '';
}
