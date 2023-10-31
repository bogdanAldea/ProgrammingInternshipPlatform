import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Spinner } from './spinner/spinner.component';



@NgModule({
  declarations: [
    Spinner
  ],
  imports: [
    CommonModule
  ],
  exports: [Spinner]
})
export class SpinnerModule { }
