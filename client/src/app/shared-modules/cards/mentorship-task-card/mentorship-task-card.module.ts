import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MentorshipTaskCardComponent } from './mentorship-task-card/mentorship-task-card.component';
import { AvatarsModule } from '../../avatars/avatars.module';
import {MatDatepickerModule} from '@angular/material/datepicker';



@NgModule({
  declarations: [
    MentorshipTaskCardComponent
  ],
  imports: [
    CommonModule,
    AvatarsModule,
    MatDatepickerModule
  ],
  exports: [
    MentorshipTaskCardComponent
  ]
})
export class MentorshipTaskCardModule { }
