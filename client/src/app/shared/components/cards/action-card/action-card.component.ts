import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'action-card',
  templateUrl: './action-card.component.html',
  styleUrls: ['./action-card.component.scss']
})
export class ActionCard {
  @Input() icon: string | undefined;
  @Input() description: string | undefined;
  @Input() actionName: string | undefined;
  @Output() executeWhenClicked: EventEmitter<void> = new EventEmitter<void>();

  public execute = () => {
    this.executeWhenClicked.emit();
  }
}
