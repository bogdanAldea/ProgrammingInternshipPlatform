import { Component, Input } from '@angular/core';
import { AbstractInputComponent } from '../../abstracts/abstract-input/abstract-input.component';
import { FieldType } from 'src/app/views/helpers/FieldType';

@Component({
  selector: 'app-date-picker',
  templateUrl: './date-picker.component.html',
  styleUrls: ['./date-picker.component.scss']
})
export class DatePickerComponent implements AbstractInputComponent {
  @Input() identifier: string | undefined;
  @Input() icon: string | undefined;
  @Input() label: string | undefined;
  @Input() prepopulatedDate: Date | undefined;
  type?: string | FieldType | undefined = FieldType.date;
  public selectedValue: string | undefined;
  
  public getSelectedValue = (convertValue?: (value: any | undefined, type: string | FieldType | undefined) => any): string | undefined => {return this.selectedValue};

}
