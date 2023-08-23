import { InjectionToken, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DomainModule } from '../domain/domain.module';
import { GetAllInternships } from './internship-hub/handler/InternshipApplicationHandler';




@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    DomainModule
  ],
})
export class ApplicationModule { }
