import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccountListingComponent } from './account-listing/account-listing.component';

const routes: Routes = 
[
  {
    path: '',
    component: AccountListingComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AccountsManagementRoutingModule { }
