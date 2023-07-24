import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { InternshipManagementRoutingModule } from './internship-management-routing.module';
import { InternshipListingComponent } from './internship-listing/internship-listing.component';


@NgModule({
  declarations: [
    InternshipListingComponent
  ],
  imports: [
    CommonModule,
    InternshipManagementRoutingModule
  ]
})
export class InternshipManagementModule { }
