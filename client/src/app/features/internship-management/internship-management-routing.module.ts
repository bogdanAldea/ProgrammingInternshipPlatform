import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InternshipListingComponent } from './internship-listing/internship-listing.component';
import { InternshipOptionsComponent } from './internship-options/internship-options.component';

const routes: Routes = 
[
  {
    path: '',
    component: InternshipListingComponent
  },

  {
    path: ':id/options',
    component: InternshipOptionsComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class InternshipManagementRoutingModule { }
