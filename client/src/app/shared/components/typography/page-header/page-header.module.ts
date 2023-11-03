import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PageHeader } from './page-header.component';



@NgModule({
  declarations: [PageHeader],
  imports: [
    CommonModule
  ],
  exports: [PageHeader]
})
export class PageHeaderModule { }
