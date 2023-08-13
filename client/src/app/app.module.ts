import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavigationsModule } from './shared-modules/navigations/navigations.module';
import { LayoutsModule } from './shared-modules/layouts/layouts.module';
import { AvatarsModule } from './shared-modules/avatars/avatars.module';
import { AuthenticationInterceptor } from './core/interceptors/authentication.interceptor';
import { SandboxComponent } from './features/sandbox/sandbox.component';
import { MentorshipParticipantCardComponent } from './shared-modules/cards/internship-cards/mentorship/mentorship-participant-card/mentorship-participant-card.component';
import { InternshipCardsModule } from './shared-modules/cards/internship-cards/internship-cards.module';

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
    InternshipCardsModule
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
