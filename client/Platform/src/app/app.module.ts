import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SharedModule } from './shared/shared/shared.module';
import { InternshipManagementModule } from './features/internship-management/internship-management/internship-management.module';
import { InternshipListViewComponent } from './features/internship-management/internship-list-view/internship-list-view.component';
import { AccountsListViewComponent } from './features/authentication/accounts-list-view/accounts-list-view.component';
import { AuthenticationModule } from './features/authentication/authentication/authentication.module';

@NgModule({
  declarations: [
    AppComponent,
    InternshipListViewComponent,
    AccountsListViewComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    SharedModule,
    InternshipManagementModule,
    AuthenticationModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
