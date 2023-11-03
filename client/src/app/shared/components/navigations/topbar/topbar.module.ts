import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Topbar } from './topbar.component';



@NgModule({
  declarations: [
    Topbar
  ],
  imports: [
    CommonModule
  ],
  exports: [Topbar]
})
export class TopbarModule { }
