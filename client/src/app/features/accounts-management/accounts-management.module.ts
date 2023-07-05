import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AccountsManagementRoutingModule } from './accounts-management-routing.module';
import { AccountListingComponent } from './account-listing/account-listing.component';
import { SharedModule } from 'src/app/shared/shared.module';


@NgModule({
  declarations: [
    AccountListingComponent
  ],
  imports: [
    CommonModule,
    AccountsManagementRoutingModule,
    SharedModule
  ]
})
export class AccountsManagementModule { }
