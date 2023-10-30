import { Component, Input } from '@angular/core';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'textarea-field',
  templateUrl: './textearea-field.component.html',
  styleUrls: ['./textearea-field.component.scss']
})
export class TexteareaFieldComponent {
  @Input() label = '';
  @Input() control: FormControl | undefined;
  @Input() placeholder: string | undefined;
}
