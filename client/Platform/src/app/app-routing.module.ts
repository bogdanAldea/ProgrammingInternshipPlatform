import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InternshipListViewComponent } from './features/internship-management/internship-list-view/component/internship-list-view.component';
import { AccountsListViewComponent } from './features/authentication/accounts-list-view/accounts-list-view.component';
import { ContextLayoutComponent } from './shared/layouts/context-layout/context-layout.component';

const routes: Routes = [
  {
    path: "",
    component: ContextLayoutComponent,
    children: [
      {
        path: "internships",
        component: InternshipListViewComponent,
      },
      {
        path: "accounts",
        component: AccountsListViewComponent,
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
