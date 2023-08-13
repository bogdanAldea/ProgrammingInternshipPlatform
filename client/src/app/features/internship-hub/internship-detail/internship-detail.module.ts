import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InternshipDetailRoutingModule } from './internship-detail-routing.module';
import { InternshipDetailComponent } from './internship-detail/internship-detail.component';


@NgModule({
  declarations: [
    InternshipDetailComponent
  ],
  imports: [
    CommonModule,
    InternshipDetailRoutingModule
  ]
})
export class InternshipDetailModule { }
