import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MentorshipsComponent } from '../settings/mentorships/mentorships.component';

const routes: Routes = [
  {
    path: 'mentorships',
    component: MentorshipsComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class InternshipDetailRoutingModule { }
