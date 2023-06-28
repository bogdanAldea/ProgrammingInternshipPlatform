import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InternshipListingModule } from './internship-listing/internship-listing.module';
import { InternshipDetailModule } from './internship-detail/internship-detail.module';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    InternshipListingModule,
    InternshipDetailModule
  ]
})
export class InternshipManagementModule { }
