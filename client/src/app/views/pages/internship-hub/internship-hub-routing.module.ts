import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InternshipListingComponent } from './internship-listing/internship-listing.component';
import { InternshipDetailComponent } from './internship-detail/internship-detail/internship-detail.component';

const routes: Routes = [
  {
    path: '',
    component: InternshipListingComponent
  },
  {
    path: ':id',
    component: InternshipDetailComponent,
    children: [
      {
        path: '',
        loadChildren: () => import('./internship-detail/internship-detail.module')
        .then(module => module.InternshipDetailModule)
      },
    ]
  }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class InternshipHubRoutingModule { }
