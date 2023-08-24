import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AvatarsModule } from './views/components/avatars/avatars.module';
import { ActionCardsModule } from './views/components/cards/action-cards/action-cards.module';
import { InternshipCardsModule } from './views/components/cards/internship-cards/internship-cards.module';
import { MentorshipTaskCardModule } from './views/components/cards/mentorship-task-card/mentorship-task-card.module';
import { LayoutsModule } from './views/components/layouts/layouts.module';
import { NavigationsModule } from './views/components/navigations/navigations.module';
import { SandboxComponent } from './views/pages/sandbox/sandbox.component';
import { ViewModule } from './views/view.module';
import { IInternshipService } from './application/service/IInternshipService';
import { InternshipService } from './services/internship-hub/internship.service';
import { DropdownsModule } from './views/components/dropdowns/dropdowns.module';
import { InternshipHubModule } from './views/pages/internship-hub/internship-hub.module';
import { FieldsModule } from './views/components/fields/fields.module';
import { ButtonsModule } from './views/components/buttons/buttons.module';
import { NewAuthenticationInterceptor } from './services/interceptors/authentication.interceptor';
import { CenterApplicationHandler } from './application/centers/handlers/CenterApplicationHandler';
import { ICenterService } from './application/service/ICenterService';
import { CentersService } from './services/centers/centers.service';
import { InternshipApplicationHandler } from './application/internship-hub/handler/InternshipApplicationHandler';
import { IInternshipApplicationHandler } from './application/internship-hub/handler/IInternshipApplicationHandler';
import { ICenterApplicationHandler } from './application/centers/handlers/ICenterApplicationHandler';
import { IAccountApplicationHandler } from './application/accounts/handlers/IAccountApplicationHandler';
import { AccountApplicationHandler } from './application/accounts/handlers/AccountApplicationHandler';
import { IAccountsService } from './application/service/IAccountService';
import { AccountsService } from './services/accounts/accounts.service';
import { StepsModule } from './views/components/steps/steps.module';



@NgModule({
  declarations: [
    AppComponent,
    SandboxComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    NavigationsModule,
    LayoutsModule,
    AvatarsModule,
    InternshipCardsModule,
    ActionCardsModule,
    MentorshipTaskCardModule,
    DropdownsModule,
    FieldsModule,
    ViewModule,
    InternshipHubModule,
    ButtonsModule,
    StepsModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: NewAuthenticationInterceptor,
      multi: true,
    },
    {
      provide: IInternshipApplicationHandler, 
      useClass: InternshipApplicationHandler
    },
    {
      provide: IInternshipService, 
      useClass: InternshipService
    },
    {
      provide: ICenterApplicationHandler,
      useClass: CenterApplicationHandler
    },
    {
      provide: ICenterService,
      useClass: CentersService
    },
    {
      provide: IAccountApplicationHandler,
      useClass: AccountApplicationHandler,
    },
    {
      provide: IAccountsService,
      useClass: AccountsService
    }

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
