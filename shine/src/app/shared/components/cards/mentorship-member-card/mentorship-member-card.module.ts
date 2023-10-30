import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MentorshipMemberCard } from './mentorship-member-card/mentorship-member-card.component';
import { AvatarsModule } from '../../avatars/avatars.module';
import { ActionButtonModule } from '../../buttons/action-button/action-button.module';



@NgModule({
  declarations: [
    MentorshipMemberCard
  ],
  imports: [
    CommonModule,
    AvatarsModule,
    ActionButtonModule
  ],
  exports: [MentorshipMemberCard]
})
export class MentorshipMemberCardModule { }
