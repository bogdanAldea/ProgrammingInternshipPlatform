import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MentorshipTaskCardComponent } from './mentorship-task-card/mentorship-task-card.component';
import { AvatarsModule } from '../../avatars/avatars.module';
import { PickersModule } from '../../pickers/pickers.module';



@NgModule({
  declarations: [
    MentorshipTaskCardComponent
  ],
  imports: [
    CommonModule,
    AvatarsModule,
    PickersModule
  ],
  exports: [
    MentorshipTaskCardComponent
  ]
})
export class MentorshipTaskCardModule { }
