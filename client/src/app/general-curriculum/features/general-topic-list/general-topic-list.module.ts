import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { GeneralCurriculumListRoutingModule } from './general-topic-list-routing.module';
import { GeneralCurriculumListPage } from './general-curriculum-list.component';
import { Container } from 'src/app/shared/components/layouts/container/container.component';
import { PageHeader } from 'src/app/shared/components/typography/page-header/page-header.component';
import { HttpClientModule } from '@angular/common/http';
import { TopicCard } from '../../components/topic-card/topic-card.component';
import {MatMenuModule} from '@angular/material/menu';
import { MatDialogModule } from '@angular/material/dialog';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import { AddEditTopicDialog } from '../../components/add-edit-topic-dialog/add-edit-topic-dialog.component';
import { ActionButtonModule } from 'src/app/shared/components/buttons/action-button/action-button.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FieldsModule } from 'src/app/shared/components/fields/fields.module';
import { SpinnerModule } from 'src/app/shared/components/spinner/spinner.module';
import { VersionateTopicDialog } from '../../components/versionate-topic-dialog/versionate-topic-dialog.component';
import {MatCheckboxModule} from '@angular/material/checkbox';

@NgModule({
  declarations: [
    Container,
    PageHeader,
    GeneralCurriculumListPage,
    TopicCard,
    AddEditTopicDialog,
    VersionateTopicDialog
  ],
  imports: [
    CommonModule,
    FormsModule,
    GeneralCurriculumListRoutingModule,
    HttpClientModule,
    MatMenuModule,
    MatDialogModule,
    MatInputModule,
    MatFormFieldModule,
    MatCheckboxModule,
    ActionButtonModule,
    ReactiveFormsModule,
    FieldsModule,
    SpinnerModule
  ]
})
export class GeneralCurriculumListModule { }
