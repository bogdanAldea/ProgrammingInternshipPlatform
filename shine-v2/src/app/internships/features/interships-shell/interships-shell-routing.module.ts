import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('../interships-list/interships-list.module')
    .then(module => module.IntershipsListModule)
  },

  {
    path: ':id',
    loadChildren: () => import('../internship-detail/internship-detail.module')
    .then(module => module.InternshipDetailModule)
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class IntershipsShellRoutingModule { }
