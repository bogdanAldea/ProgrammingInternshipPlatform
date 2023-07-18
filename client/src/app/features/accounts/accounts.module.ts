import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AccountsRoutingModule } from './accounts-routing.module';
import { AccountsListComponent } from './accounts-list/accounts-list.component';
import { SharedModule } from 'src/app/shared/shared.module';


@NgModule({
  declarations: [
    AccountsListComponent
  ],
  imports: [
    CommonModule,
    AccountsRoutingModule,
    SharedModule
  ]
})
export class AccountsModule { }
