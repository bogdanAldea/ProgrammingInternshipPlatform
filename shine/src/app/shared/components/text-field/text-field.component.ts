import { Component, Input } from '@angular/core';

@Component({
  selector: 'text-field',
  templateUrl: './text-field.component.html',
  styleUrls: ['./text-field.component.scss']
})
export class TextField {
  @Input() identifier: string | undefined;
  @Input() icon: string | undefined;
  @Input() label: string | undefined;
  @Input() type: string = 'text';
  public selectedValue: string | undefined;
  
  public constructor(){}

  public getSelectedValue = (): string | undefined => {
    return this.selectedValue ? this.selectedValue : this.label
  }
}
