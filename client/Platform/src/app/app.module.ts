import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SharedModule } from './shared/shared.module';
import { InternshipManagementModule } from './features/internship-management/internship-management/internship-management.module';
import { AuthenticationModule } from './features/authentication/authentication/authentication.module';
import { RouterModule } from '@angular/router';
import { OrganisationModule } from './features/organisation/organisation.module';
import { CurriculumModule } from './features/curriculum/curriculum.module';
import { OverviewModule } from './features/overview/overview.module';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    HttpClientModule,
    RouterModule, 
    BrowserModule,
    AppRoutingModule,
    SharedModule,
    InternshipManagementModule,
    AuthenticationModule,
    OrganisationModule,
    CurriculumModule,
    OverviewModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
