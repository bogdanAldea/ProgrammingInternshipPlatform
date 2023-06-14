import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InternshipListViewComponent } from './features/internship-management/internship-list-view/internship-list-view.component';
import { AccountsListViewComponent } from './features/authentication/accounts-list-view/accounts-list-view.component';

const routes: Routes = [
  {path: '', component: InternshipListViewComponent},
  {path: 'accounts', component: AccountsListViewComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
