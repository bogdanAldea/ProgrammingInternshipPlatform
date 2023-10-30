import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { InternshipListRoutingModule } from './internship-list-routing.module';
import { InternshipListPage } from './internship-list.page.component';
import { SpinnerModule } from 'src/app/shared/components/spinners/spinner/spinner.module';
import { AvatarsModule } from 'src/app/shared/components/avatars/avatars.module';
import { InternshipsTable } from '../../views/internships-table/internships-table.component';
import { ActionCardModule } from 'src/app/shared/components/cards/action-card/action-card.module';
import { ContainerModule } from 'src/app/shared/components/layout/container/container.module';
import { TextCellModule } from 'src/app/shared/components/tables/text-cell/text-cell.module';


@NgModule({
  declarations: [
    InternshipListPage,
    InternshipsTable
  ],
  imports: [
    ActionCardModule,
    AvatarsModule,
    CommonModule,
    ContainerModule,
    InternshipListRoutingModule,
    SpinnerModule,
    TextCellModule
  ]
})
export class InternshipListModule { }
