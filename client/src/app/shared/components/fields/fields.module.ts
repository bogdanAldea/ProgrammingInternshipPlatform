import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InputFieldComponent } from './input-field/input-field.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { ReactiveFormsModule } from '@angular/forms';
import { TexteareaFieldComponent } from './textearea-field/textearea-field.component';



@NgModule({
  declarations: [
    InputFieldComponent,
    TexteareaFieldComponent
  ],
  imports: [
    CommonModule,
    MatInputModule,
    MatFormFieldModule,
    ReactiveFormsModule,
  ],
  exports : [
    InputFieldComponent,
    TexteareaFieldComponent
  ]
})
export class FieldsModule { }
