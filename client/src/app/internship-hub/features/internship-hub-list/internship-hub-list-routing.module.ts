import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InternshipHubListPage } from './internship-hub-list.page.component';

const routes: Routes = [
  {
    path: '',
    component: InternshipHubListPage,
    data: {title: 'Internships'}
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class InternshipHubListRoutingModule { }
