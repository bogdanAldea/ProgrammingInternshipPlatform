import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { InternshipListComponent } from '../internship-listing/internship-list/internship-list.component';
import { OptionsComponent } from '../internship-detail/internship-options/options/options.component';
import { SettingsComponent } from '../internship-detail/internship-settings/settings/settings.component';
import { InternsComponent } from '../internship-detail/internship-interns/interns/interns.component';
import { MentorshipsComponent } from '../internship-detail/internship-mentorships/mentorships/mentorships.component';
import { CurriculumComponent } from '../internship-detail/internship-curriculum/curriculum/curriculum.component';
import { TrainersComponent } from '../internship-detail/internship-trainers/trainers/trainers.component';

const routes: Routes = 
[
  {
    path: '',
    component: InternshipListComponent
  },

  {
    path: ':id',
    component: OptionsComponent
  },

  {
    path: ':id/settings',
    component: SettingsComponent
  },

  {
    path: ':id/interns',
    component: InternsComponent
  },

  {
    path: ':id/trainers',
    component: TrainersComponent
  },

  {
    path: ':id/mentorships',
    component: MentorshipsComponent
  },

  {
    path: ':id/curriculum',
    component: CurriculumComponent
  },
]


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class InternshipRoutingModule { }
