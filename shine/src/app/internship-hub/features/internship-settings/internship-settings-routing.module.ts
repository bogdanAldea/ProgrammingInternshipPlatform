import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SetupComponent } from './setup/setup.component';
import { TrainersComponent } from './trainers/trainers.component';
import { MentorshipComponent } from './mentorship/mentorship.component';
import { MentorshipDetailComponent } from './mentorship-detail/mentorship-detail.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'setup',
    pathMatch: 'full'
  },
  {
    path: 'setup',
    component: SetupComponent
  },
  {
    path: 'trainers',
    component: TrainersComponent
  },
  {
    path: 'mentorships',
    component: MentorshipComponent
  },
  {
    path: 'mentorships/:mentorshipId',
    component: MentorshipDetailComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class InternshipSettingsRoutingModule { }
