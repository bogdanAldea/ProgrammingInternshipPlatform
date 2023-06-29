import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InternshipSettingsModule } from './internship-settings/internship-settings.module';
import { InternshipInternsModule } from './internship-interns/internship-interns.module';
import { InternshipTrainersModule } from './internship-trainers/internship-trainers.module';
import { InternshipMentorshipsModule } from './internship-mentorships/internship-mentorships.module';
import { InternshipCurriculumModule } from './internship-curriculum/internship-curriculum.module';
import { InternshipOptionsModule } from './internship-options/internship-options.module';



@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    InternshipOptionsModule,
    InternshipSettingsModule,
    InternshipInternsModule,
    InternshipTrainersModule,
    InternshipMentorshipsModule,
    InternshipCurriculumModule
  ]
})
export class InternshipDetailModule { }
