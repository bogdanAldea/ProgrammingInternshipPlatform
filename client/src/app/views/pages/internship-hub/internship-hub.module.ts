import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InternshipHubRoutingModule } from './internship-hub-routing.module';
import { InternshipListingComponent } from './internship-listing/internship-listing.component';
import { MentorshipsComponent } from './settings/mentorships/mentorships.component';
import { InternshipCardsModule } from '../../components/cards/internship-cards/internship-cards.module';


@NgModule({
  declarations: [
    InternshipListingComponent,
    MentorshipsComponent,
  ],
  imports: [
    CommonModule,
    InternshipHubRoutingModule,
    InternshipCardsModule
  ]
})
export class InternshipHubModule { }
