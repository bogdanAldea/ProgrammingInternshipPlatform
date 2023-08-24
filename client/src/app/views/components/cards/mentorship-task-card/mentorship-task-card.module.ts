import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MentorshipTaskCardComponent } from './mentorship-task-card/mentorship-task-card.component';
import { AvatarsModule } from '../../avatars/avatars.module';
import { FieldsModule } from '../../fields/fields.module';


@NgModule({
  declarations: [
    MentorshipTaskCardComponent
  ],
  imports: [
    CommonModule,
    AvatarsModule,
    FieldsModule
  ],
  exports: [
    MentorshipTaskCardComponent
  ]
})
export class MentorshipTaskCardModule { }
