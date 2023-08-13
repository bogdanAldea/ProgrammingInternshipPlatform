import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InternshipDetailRoutingModule } from './internship-detail-routing.module';
import { InternshipDetailComponent } from './internship-detail/internship-detail.component';
import { NavigationsModule } from 'src/app/shared-modules/navigations/navigations.module';


@NgModule({
  declarations: [
    InternshipDetailComponent
  ],
  imports: [
    CommonModule,
    InternshipDetailRoutingModule,
    NavigationsModule
  ]
})
export class InternshipDetailModule { }
