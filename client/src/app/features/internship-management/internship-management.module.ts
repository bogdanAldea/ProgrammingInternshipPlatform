import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { InternshipManagementRoutingModule } from './internship-management-routing.module';
import { InternshipListingComponent } from './internship-listing/internship-listing.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { InternshipOptionsComponent } from './internship-options/internship-options.component';


@NgModule({
  declarations: [
    InternshipListingComponent,
    InternshipOptionsComponent
  ],
  imports: [
    CommonModule,
    InternshipManagementRoutingModule,
    SharedModule
  ]
})
export class InternshipManagementModule { }
