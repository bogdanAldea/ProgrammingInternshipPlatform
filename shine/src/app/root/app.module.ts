import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NodeModule } from '../shared/components/navigations/node/node.module';
import { InlineNavbarModule } from '../shared/components/navigations/inline-navbar/inline-navbar.module';
import { AvatarsModule } from '../shared/components/avatars/avatars.module';
import { ActionButtonModule } from '../shared/components/buttons/action-button/action-button.module';
import { RouterModule } from '@angular/router';
import { LayoutWithNavigationModule } from '../shared/components/layout/layout-with-navigation/layout-with-navigation.module';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { AuthorizationInterceptor } from '../shared/interceptors/authorization.interceptor';
import { SpinnerModule } from '../shared/components/spinners/spinner/spinner.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TextCellModule } from '../shared/components/tables/text-cell/text-cell.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    ActionButtonModule,
    AppRoutingModule,
    AvatarsModule,
    BrowserModule,
    InlineNavbarModule,
    HttpClientModule,
    LayoutWithNavigationModule,
    NodeModule,
    RouterModule,
    SpinnerModule,
    BrowserAnimationsModule,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthorizationInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
