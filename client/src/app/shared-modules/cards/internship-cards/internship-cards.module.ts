import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MentorshipParticipantCardComponent } from './mentorship/mentorship-participant-card/mentorship-participant-card.component';
import { AvatarsModule } from '../../avatars/avatars.module';



@NgModule({
  declarations: [
    MentorshipParticipantCardComponent
  ],
  imports: [
    CommonModule,
    AvatarsModule
  ],
  exports: [
    MentorshipParticipantCardComponent
  ]
})
export class InternshipCardsModule { }
