import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SigninRoutingModule } from './signin-routing.module';
import { Signin } from './signin.component';


@NgModule({
  declarations: [
    Signin
  ],
  imports: [
    CommonModule,
    SigninRoutingModule
  ]
})
export class SigninModule { }
