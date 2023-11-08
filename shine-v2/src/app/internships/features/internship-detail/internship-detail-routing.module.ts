import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InternshipDetailPage } from './internship-detail.page.component';

const routes: Routes = [
  {
    path: '',
    component: InternshipDetailPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class InternshipDetailRoutingModule { }
