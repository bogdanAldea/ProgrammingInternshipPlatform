import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MentorshipParticipantCardComponent } from './mentorship/mentorship-participant-card/mentorship-participant-card.component';
import { AvatarsModule } from '../../avatars/avatars.module';
import { ActionCardComponent } from '../action-cards/action-card/action-card.component';
import { ButtonsModule } from '../../buttons/buttons.module';



@NgModule({
  declarations: [
    MentorshipParticipantCardComponent,
  ],
  imports: [
    CommonModule,
    AvatarsModule,
    ButtonsModule
  ],
  exports: [
    MentorshipParticipantCardComponent,
  ]
})
export class InternshipCardsModule { }
