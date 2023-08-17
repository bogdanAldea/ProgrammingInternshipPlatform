import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InternshipHubRoutingModule } from './internship-hub-routing.module';
import { InternshipListingComponent } from './internship-listing/internship-listing.component';
import { MentorshipsComponent } from './settings/mentorships/mentorships.component';
import { ActionCardsModule } from '../../components/cards/action-cards/action-cards.module';
import {MatProgressBarModule} from '@angular/material/progress-bar';
import { DropdownsModule } from '../../components/dropdowns/dropdowns.module';



@NgModule({
  declarations: [
    InternshipListingComponent,
    MentorshipsComponent,
  ],
  imports: [
    CommonModule,
    InternshipHubRoutingModule,
    ActionCardsModule,
    MatProgressBarModule,
    DropdownsModule
  ]
})
export class InternshipHubModule { }
