import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'action-button',
  templateUrl: './action-button.component.html',
  styleUrls: ['./action-button.component.scss']
})
export class ActionButton implements OnInit {
  @Input() label: string | undefined;
  @Input() icon: string | undefined;
  @Input() appearance: string = 'filled'
  @Input() isDisabled: boolean = false;
  @Output() executeOnClick: EventEmitter<void> = new EventEmitter<void>();

  public ngOnInit(): void {
    if (this.isDisabled)
      this.appearance = 'disabled-button'
  }

  public execute = (): void => {
    this.executeOnClick.emit();
  }
}
