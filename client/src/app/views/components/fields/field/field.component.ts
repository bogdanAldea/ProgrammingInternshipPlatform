import { Component } from '@angular/core';
import { AbstractInputComponent } from '../../abstracts/abstract-input/abstract-input.component';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-field',
  templateUrl: './field.component.html',
  styleUrls: ['./field.component.scss']
})
export class FieldComponent extends AbstractInputComponent {

}
