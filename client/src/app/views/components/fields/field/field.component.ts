import { Component, Input } from '@angular/core';
import { AbstractInputComponent } from '../../abstracts/abstract-input/abstract-input.component';
import { FormControl } from '@angular/forms';
import { FieldType } from 'src/app/views/helpers/FieldType';

@Component({
  selector: 'app-field',
  templateUrl: './field.component.html',
  styleUrls: ['./field.component.scss']
})
export class FieldComponent extends AbstractInputComponent {
  @Input() override type?: string | FieldType | undefined;
  @Input() fieldType?: string = 'text';
}
