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
import { ReactiveFormsModule } from '@angular/forms';
import { FieldsModule } from 'src/app/shared/components/fields/fields.module';

@NgModule({
  declarations: [
    Container,
    PageHeader,
    GeneralCurriculumListPage,
    TopicCard,
    AddEditTopicDialog,
  ],
  imports: [
    CommonModule,
    GeneralCurriculumListRoutingModule,
    HttpClientModule,
    MatMenuModule,
    MatDialogModule,
    MatInputModule,
    MatFormFieldModule,
    ActionButtonModule,
    ReactiveFormsModule,
    FieldsModule
  ]
})
export class GeneralCurriculumListModule { }
