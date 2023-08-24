import { Component, Input } from '@angular/core';
import { AbstractInputComponent } from '../../abstracts/abstract-input/abstract-input.component';

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
  public selectedValue: string | undefined;
  
  public getSelectedValue = (): string | undefined => {return this.selectedValue};

}
