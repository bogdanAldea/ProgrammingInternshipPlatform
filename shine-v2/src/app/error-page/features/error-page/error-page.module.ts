import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ErrorPage } from './error.page.component';
import { ContainerModule } from 'src/app/shineUI/layouts/container/container.module';



@NgModule({
  declarations: [
    ErrorPage
  ],
  imports: [
    CommonModule,
    ContainerModule
  ],
  exports: [
    ErrorPage
  ]
})
export class ErrorPageModule { }
