import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InternshipHubRoutingModule } from './internship-hub-routing.module';
import { InternshipListingComponent } from './internship-listing/internship-listing.component';
import { MentorshipsComponent } from './settings/mentorships/mentorships.component';
import { ActionCardsModule } from '../../components/cards/action-cards/action-cards.module';
import {MatProgressBarModule} from '@angular/material/progress-bar';
import { DropdownsModule } from '../../components/dropdowns/dropdowns.module';
import { FieldsModule } from '../../components/fields/fields.module';
import { ButtonsModule } from '../../components/buttons/buttons.module';
import { InternshipCardsModule } from '../../components/cards/internship-cards/internship-cards.module';
import { MatDialogModule } from '@angular/material/dialog';
import {MatStepperModule} from '@angular/material/stepper';
import { SetupFormComponent } from './internship-wizard/form-steps/setup-form/setup-form.component';
import { TrainersFormComponent } from './internship-wizard/form-steps/trainers-form/trainers-form.component';
import { InternsFormComponent } from './internship-wizard/form-steps/interns-form/interns-form.component';
import { MentorshipsFormComponent } from './internship-wizard/form-steps/mentorships-form/mentorships-form.component';
import { CreateInternshipWizardComponent } from './internship-wizard/create-internship-wizard/create-internship-wizard.component';
import { StepsModule } from '../../components/steps/steps.module';


@NgModule({
  declarations: [
    InternshipListingComponent,
    MentorshipsComponent,
    SetupFormComponent,
    TrainersFormComponent,
    InternsFormComponent,
    MentorshipsFormComponent,
    CreateInternshipWizardComponent,
  ],
  imports: [
    CommonModule,
    InternshipHubRoutingModule,
    ActionCardsModule,
    MatProgressBarModule,
    DropdownsModule,
    FieldsModule,
    ButtonsModule,
    InternshipCardsModule,
    MatDialogModule,
    MatStepperModule,
    StepsModule
  ],
  exports: [
    SetupFormComponent,
    TrainersFormComponent,
    InternsFormComponent,
    MentorshipsFormComponent,
    CreateInternshipWizardComponent
  ],
  providers: [

  ]
})
export class InternshipHubModule { }
