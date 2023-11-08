import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InternshipHubListRoutingModule } from './internship-hub-list-routing.module';
import { InternshipHubListPage } from './internship-hub-list.page.component';
import { InternshipListTable } from '../../components/internship-list-table/internship-list-table.component';
import { InternshipFilter } from '../../components/intership-filter/intership-filter.component';
import {MatSelectModule} from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { ReactiveFormsModule } from '@angular/forms';
import { ActionButtonModule } from 'src/app/shared/components/buttons/action-button/action-button.module';
import { ActionCardModule } from 'src/app/shared/components/cards/action-card/action-card.module';
import { RouterModule } from '@angular/router';
import { ContainerModule } from 'src/app/shared/components/layouts/container/container.module';
import { PageHeaderModule } from 'src/app/shared/components/typography/page-header/page-header.module';
import { SpinnerModule } from 'src/app/shared/components/spinner/spinner.module';
import { ScheduleInternshipDialog } from '../../components/schedule-internship-dialog/schedule-internship.dialog.component';
import { MatDialogModule } from '@angular/material/dialog';
import { FieldsModule } from 'src/app/shared/components/fields/fields.module';
import {MatRadioModule} from '@angular/material/radio'
import { GenericDialogModule } from 'src/app/shared/components/dialogs/generic-dialog/generic-dialog.module';

@NgModule({
  declarations: [
    InternshipHubListPage,
    InternshipListTable,
    InternshipFilter,
    ScheduleInternshipDialog,
  ],
  imports: [
    CommonModule,
    InternshipHubListRoutingModule,
    MatSelectModule,
    MatFormFieldModule,
    ReactiveFormsModule,
    ActionButtonModule,
    ActionCardModule,
    RouterModule,
    ContainerModule,
    PageHeaderModule,
    SpinnerModule,
    MatDialogModule,
    FieldsModule, 
    MatRadioModule,
    GenericDialogModule
  ]
})
export class InternshipHubListModule { }
