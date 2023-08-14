import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AuthenticationInterceptor } from './core/interceptors/authentication.interceptor';
import { AvatarsModule } from './views/components/avatars/avatars.module';
import { ActionCardsModule } from './views/components/cards/action-cards/action-cards.module';
import { InternshipCardsModule } from './views/components/cards/internship-cards/internship-cards.module';
import { MentorshipTaskCardModule } from './views/components/cards/mentorship-task-card/mentorship-task-card.module';
import { LayoutsModule } from './views/components/layouts/layouts.module';
import { NavigationsModule } from './views/components/navigations/navigations.module';
import { SandboxComponent } from './views/pages/sandbox/sandbox.component';
import { ViewModule } from './views/view.module';



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
    ViewModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthenticationInterceptor,
      multi: true,
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
