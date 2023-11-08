import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SidebarLayoutModule } from '../shineUI/layouts/sidebar-layout/sidebar-layout.module';
import { ContainerModule } from '../shineUI/layouts/container/container.module';
import { ErrorPageModule } from '../error-page/features/error-page/error-page.module';
import { HTTP_INTERCEPTORS, HttpClient, HttpClientModule } from '@angular/common/http';
import { AuthenticationInterceptor } from '../shared/interceptors/authentication.interceptor';
import { ApiFailureInterceptor } from '../shared/interceptors/api-failure.interceptor';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    SidebarLayoutModule,
    ErrorPageModule,
    HttpClientModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthenticationInterceptor,
      multi: true,
    },

    {
      provide: HTTP_INTERCEPTORS,
      useClass: ApiFailureInterceptor,
      multi: true,
    },
    
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
