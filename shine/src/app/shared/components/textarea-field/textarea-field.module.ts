import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TextareaField } from '../textarea-field.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    TextareaField
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [TextareaField]
})
export class TextareaFieldModule { }
