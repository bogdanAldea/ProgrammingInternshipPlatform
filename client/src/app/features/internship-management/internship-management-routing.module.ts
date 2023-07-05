import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InternshipManagementComponent } from './internship-management/internship-management.component';
import { InternshipListingComponent } from './internship-listing/internship-listing.component';
import { InternshipDetailComponent } from './internship-detail/internship-detail.component';
import { TrainersComponent } from './internship-detail/setings/trainers/trainers.component';
import { InternsComponent } from './internship-detail/setings/interns/interns.component';
import { MentorshipComponent } from './internship-detail/setings/mentorship/mentorship.component';
import { CurriculumComponent } from './internship-detail/setings/curriculum/curriculum.component';
import { ConfigurationComponent } from './internship-detail/setings/configuration/configuration.component';

const routes: Routes = 
[
  {
    path: '',
    component: InternshipManagementComponent,
    children: 
    [
      {
        path: '',
        component: InternshipListingComponent
      },

      {
        path: ':id',
        component: InternshipDetailComponent,
        
      },

      {
        path: ':id/trainers',
        component: TrainersComponent
      },

      {
        path: ':id/interns',
        component: InternsComponent
      },

      {
        path: ':id/curriculum',
        component: CurriculumComponent
      },

      {
        path: ':id/trainers',
        component: TrainersComponent
      },

      {
        path: ':id/settings',
        component: ConfigurationComponent
      },

      {
        path: ':id/mentorships',
        component: MentorshipComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class InternshipManagementRoutingModule { }
