import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InternshipListPage } from './internship-list.page.component';

const routes: Routes = [
  {
    path: '',
    component: InternshipListPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class InternshipListRoutingModule { }
