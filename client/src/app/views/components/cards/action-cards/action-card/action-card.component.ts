import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-action-card',
  templateUrl: './action-card.component.html',
  styleUrls: ['./action-card.component.scss']
})
export class ActionCardComponent {
  @Input() icon: string | undefined;
  @Input() description: string | undefined;
  @Input() actionName: string | undefined;
}
