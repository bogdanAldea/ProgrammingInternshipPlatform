import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('../internship-hub-list/internship-hub-list.module')
    .then(module => module.InternshipHubListModule)
  },

  {
    path: ':id',
    loadChildren: () => import('../internship-hub-detail/internship-hub-detail.module')
    .then(module => module.InternshipHubDetailModule)
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class InternshipHubShellRoutingModule { }
