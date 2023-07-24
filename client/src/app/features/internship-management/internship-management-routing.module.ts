import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InternshipListingComponent } from './internship-listing/internship-listing.component';

const routes: Routes = 
[
  {
    path: '',
    component: InternshipListingComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class InternshipManagementRoutingModule { }
