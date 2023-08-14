import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InternshipDetailRoutingModule } from './internship-detail-routing.module';
import { InternshipDetailComponent } from './internship-detail/internship-detail.component';
import { NavigationsModule } from 'src/app/views/components/navigations/navigations.module';
import { RouterOutlet } from '@angular/router';



@NgModule({
  declarations: [
    InternshipDetailComponent
  ],
  imports: [
    CommonModule,
    InternshipDetailRoutingModule,
    NavigationsModule,
    RouterOutlet
  ]
})
export class InternshipDetailModule { }
