import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-action-button',
  templateUrl: './action-button.component.html',
  styleUrls: ['./action-button.component.scss']
})
export class ActionButtonComponent {
  @Input() label: string | undefined;
  @Input() icon: string | undefined;
  @Input() appearance: string = 'filled'
  @Output() executeOnClick: EventEmitter<void> = new EventEmitter<void>();

  public execute = (): void => {
    this.executeOnClick.emit();
  }
}
