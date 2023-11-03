import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InternshipHubDetailRoutingModule } from './internship-hub-detail-routing.module';
import { InternshipHubDetailPage } from './internship-hub-detail.page.component';
import { OptionsBarModule } from 'src/app/shared/components/navigations/options-bar/options-bar.module';
import { LinkNodeModule } from 'src/app/shared/components/navigations/link-node/link-node.module';
import { ConfigurationsPage } from '../options/configurations/configurations.page.component';
import { CurriculumPage } from '../options/curriculum/curriculum.page.component';
import { PageHeaderModule } from 'src/app/shared/components/typography/page-header/page-header.module';
import { ContainerModule } from 'src/app/shared/components/layouts/container/container.module';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { ActionButtonModule } from 'src/app/shared/components/buttons/action-button/action-button.module';


@NgModule({
  declarations: [
    InternshipHubDetailPage,
    ConfigurationsPage,
    CurriculumPage,
  ],
  imports: [
    CommonModule,
    InternshipHubDetailRoutingModule,
    OptionsBarModule,
    LinkNodeModule,
    PageHeaderModule,
    ContainerModule,
    MatFormFieldModule,
    MatSelectModule,
    ActionButtonModule
  ]
})
export class InternshipHubDetailModule { }
