import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminRegistrationComponent } from './admin-registration/admin-registration.component';
import { ReactiveFormsModule } from '@angular/forms';
import {MatInputModule} from '@angular/material/input';



@NgModule({
  declarations: [
    AdminRegistrationComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatInputModule
  ]
})
export class AuthencationModule { }
