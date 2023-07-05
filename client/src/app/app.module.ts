import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SharedModule } from './shared/shared.module';
import { InternshipManagementModule } from './features/internship-management/internship-management.module';
import { AuthenticationModule } from './features/authentication/authentication.module';
import { AccountsManagementModule } from './features/accounts-management/accounts-management.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    SharedModule,
    InternshipManagementModule,
    AuthenticationModule,
    AccountsManagementModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
