import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import { SignInComponent } from './sign-in/sign-in.component';
import { SignUpFormComponent } from './forms/sign-up-form/sign-up-form.component';
import { SignInFormComponent } from './forms/sign-in-form/sign-in-form.component';
import { AdminRegistrationComponent } from './admin-sign-up/admin-registration.component';



@NgModule({
  declarations: [
    AdminRegistrationComponent,
    SignInComponent,
    SignUpFormComponent,
    SignInFormComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatInputModule
  ]
})
export class AuthencationModule { }
