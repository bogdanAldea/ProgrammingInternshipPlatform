import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TextField } from './text-field.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    TextField
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule
  ],
  exports: [TextField]
})
export class TextFieldModule { }
