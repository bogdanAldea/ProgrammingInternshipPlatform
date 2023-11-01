import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ErrorPageRoutingModule } from './error-page-routing.module';
import { ErrorPage } from './error-page.component';


@NgModule({
  declarations: [
    ErrorPage
  ],
  imports: [
    CommonModule,
    ErrorPageRoutingModule
  ]
})
export class ErrorPageModule { }
