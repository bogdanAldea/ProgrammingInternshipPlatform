import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { IntershipsListRoutingModule } from './interships-list-routing.module';
import { InternshipsListComponent } from './internships-list.component';
import { ContainerModule } from 'src/app/shineUI/layouts/container/container.module';
import { InternshipListTable } from '../../components/internships-table/internships-table.component';


@NgModule({
  declarations: [
    InternshipsListComponent,
    InternshipListTable
  ],
  imports: [
    CommonModule,
    ContainerModule,
    IntershipsListRoutingModule
  ]
})
export class IntershipsListModule { }
