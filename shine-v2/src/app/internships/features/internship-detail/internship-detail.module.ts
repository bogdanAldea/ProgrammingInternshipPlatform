import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { InternshipDetailRoutingModule } from './internship-detail-routing.module';
import { InternshipDetailPage } from './internship-detail.page.component';
import { ContainerModule } from 'src/app/shineUI/layouts/container/container.module';
import { OptionbarModule } from 'src/app/shineUI/navigations/optionbar/optionbar.module';


@NgModule({
  declarations: [
    InternshipDetailPage
  ],
  imports: [
    CommonModule,
    ContainerModule,
    OptionbarModule,
    InternshipDetailRoutingModule
  ]
})
export class InternshipDetailModule { }
