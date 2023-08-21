import { ApplicationModule, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { NewAuthenticationInterceptor } from './interceptors/authentication.interceptor';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    ApplicationModule
  ],
  providers: [
  ]
})
export class ServicesModule { }
