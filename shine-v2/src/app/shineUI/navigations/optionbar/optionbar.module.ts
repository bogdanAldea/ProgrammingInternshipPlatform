import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Optionbar } from './optionbar.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    Optionbar
  ],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [
    Optionbar
  ]
})
export class OptionbarModule { }
