import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { InternshipManagementRoutingModule } from './internship-management-routing.module';
import { InternshipManagementComponent } from './internship-management/internship-management.component';
import { InternshipListingComponent } from './internship-listing/internship-listing.component';
import { InternshipDetailComponent } from './internship-detail/internship-detail.component';
import { InternsComponent } from './internship-detail/setings/interns/interns.component';
import { TrainersComponent } from './internship-detail/setings/trainers/trainers.component';
import { MentorshipComponent } from './internship-detail/setings/mentorship/mentorship.component';
import { CurriculumComponent } from './internship-detail/setings/curriculum/curriculum.component';
import { ConfigurationComponent } from './internship-detail/setings/configuration/configuration.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { HttpClientModule } from '@angular/common/http';


@NgModule({
  declarations: [
    InternshipManagementComponent,
    InternshipListingComponent,
    InternshipDetailComponent,
    InternsComponent,
    TrainersComponent,
    MentorshipComponent,
    CurriculumComponent,
    ConfigurationComponent
  ],
  imports: [
    CommonModule,
    InternshipManagementRoutingModule,
    SharedModule,
    HttpClientModule
  ]
})
export class InternshipManagementModule { }
