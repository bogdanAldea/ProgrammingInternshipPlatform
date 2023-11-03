import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InternshipHubDetailPage } from './internship-hub-detail.page.component';
import { ConfigurationsPage } from '../options/configurations/configurations.page.component';
import { CurriculumPage } from '../options/curriculum/curriculum.page.component';

const routes: Routes = [
  {
    path: '',
    component: InternshipHubDetailPage,
    children: [
      {
        path: 'configurations',
        component: ConfigurationsPage
      },

      {
        path: 'curriculum',
        component: CurriculumPage
      }
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class InternshipHubDetailRoutingModule { }
