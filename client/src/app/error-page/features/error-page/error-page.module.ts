import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ErrorPageRoutingModule } from './error-page-routing.module';
import { ErrorPage } from './error-page.component';
import { ActionButtonModule } from 'src/app/shared/components/buttons/action-button/action-button.module';
import { ContainerModule } from 'src/app/shared/components/layouts/container/container.module';
import { PageHeaderModule } from 'src/app/shared/components/typography/page-header/page-header.module';


@NgModule({
  declarations: [
    ErrorPage,
  ],
  imports: [
    CommonModule,
    ErrorPageRoutingModule,
    ActionButtonModule,
    ContainerModule,
    PageHeaderModule
  ]
})
export class ErrorPageModule { }
