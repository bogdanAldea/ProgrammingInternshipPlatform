import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InternshipManagementModule } from '../internship-management/internship-management.module';
import { AuthencationModule } from '../authentication/authencation.module';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    InternshipManagementModule,
    AuthencationModule
  ]
})
export class FeaturesModule { }
