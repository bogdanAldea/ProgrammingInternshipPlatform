import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { InternshipDetailRoutingModule } from './internship-detail-routing.module';
import { InternshipDetailPage } from './internship-detail.page.component';
import { ContainerModule } from 'src/app/shared/components/layout/container/container.module';
import { SettingsNavbarModule } from 'src/app/shared/components/navigations/settings-navbar/settings-navbar.module';


@NgModule({
  declarations: [
    InternshipDetailPage
  ],
  imports: [
    CommonModule,
    ContainerModule,
    InternshipDetailRoutingModule,
    SettingsNavbarModule,  ]
})
export class InternshipDetailModule { }
