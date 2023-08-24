import { Component, Input } from '@angular/core';
import { InputOptions } from '../InputOptions';
import { FieldType } from 'src/app/views/helpers/FieldType';

@Component({
  selector: 'app-abstract-input',
  templateUrl: './abstract-input.component.html',
  styleUrls: ['./abstract-input.component.scss']
})
export abstract class AbstractInputComponent implements InputOptions {
  @Input() type?: string | FieldType | undefined;
  @Input() identifier: string | undefined;
  @Input() icon: string | undefined;
  @Input() label: string | undefined;
  public selectedValue: string | undefined;
  
  public constructor(){}

  public getSelectedValue = (convertValue?: (value: any | undefined, type: string | FieldType | undefined) => any): string | undefined => {
    if (convertValue && this.getSelectedValue !== undefined) {
      return convertValue(this.selectedValue, this.type)
    }
    return this.selectedValue ? this.selectedValue : undefined
  }
}
