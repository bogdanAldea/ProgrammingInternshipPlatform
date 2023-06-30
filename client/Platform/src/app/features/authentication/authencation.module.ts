import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminRegistrationComponent } from './admin-registration/admin-registration.component';
import { ReactiveFormsModule } from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import { SignInComponent } from './sign-in/sign-in.component';



@NgModule({
  declarations: [
    AdminRegistrationComponent,
    SignInComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatInputModule
  ]
})
export class AuthencationModule { }
