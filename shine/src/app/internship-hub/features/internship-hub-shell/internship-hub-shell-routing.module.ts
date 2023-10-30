import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    loadChildren: () =>
      import('../internship-list/internship-list.module').then(
        (module) => module.InternshipListModule)
  },

  {
    path: ':id',
    loadChildren: () =>
      import('../internship-detail/internship-detail.module').then(
        (module) => module.InternshipDetailModule)
  },
  
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class InternshipHubShellRoutingModule { }
