import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InternshipListViewComponent } from './features/internship-management/internship-list-view/component/internship-list-view.component';
import { AccountsListViewComponent } from './features/authentication/accounts-list-view/accounts-list-view.component';
import { ContextLayoutComponent } from './shared/layouts/context-layout/context-layout.component';
import { OverviewDashboardViewComponent } from './features/overview/overview-dashboard-view/overview-dashboard-view.component';
import { CurriculumListViewComponent } from './features/curriculum/curriculum-list-view/curriculum-list-view.component';
import { OrganisationListViewComponent } from './features/organisation/organisation-list-view/organisation-list-view.component';
import { InternshipDetailViewComponent } from './features/internship-management/internship-detail-view/internship-detail-view.component';

const routes: Routes = [
  {
    path: "",
    component: ContextLayoutComponent,
    children: [
      {
        path: "overview",
        component: OverviewDashboardViewComponent,
      },
      {
        path: "internships",
        component: InternshipListViewComponent,
      },
      {
        path: "internships/:id",
        component: InternshipDetailViewComponent,
      },
      {
        path: "curriculum",
        component: CurriculumListViewComponent,
      },      
      {
        path: "accounts",
        component: AccountsListViewComponent,
      },
      {
        path: "organisation",
        component: OrganisationListViewComponent,
      },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
