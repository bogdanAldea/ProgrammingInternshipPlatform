import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InternshipHubRoutingModule } from './internship-hub-routing.module';
import { InternshipListingComponent } from './internship-listing/internship-listing.component';
import { MentorshipsComponent } from './settings/mentorships/mentorships.component';
import { ActionCardsModule } from '../../components/cards/action-cards/action-cards.module';
import {MatProgressBarModule} from '@angular/material/progress-bar';
import { DropdownsModule } from '../../components/dropdowns/dropdowns.module';
import { SetupStepComponent } from './internship-wizard/setup-step/setup-step.component';
import { FieldsModule } from '../../components/fields/fields.module';
import { TrainersStepComponent } from './internship-wizard/trainers-step/trainers-step.component';
import { ButtonsModule } from '../../components/buttons/buttons.module';
import { InternsStepComponent } from './internship-wizard/interns-step/interns-step.component';
import { InternshipCardsModule } from '../../components/cards/internship-cards/internship-cards.module';
import { MentorshipsStepComponent } from './internship-wizard/mentorships-step/mentorships-step.component';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { NewAuthenticationInterceptor } from 'src/app/services/interceptors/authentication.interceptor';
import { InternshipWizardDialogComponent } from './internship-wizard/internship-wizard-dialog/internship-wizard-dialog.component';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import {MatStepperModule} from '@angular/material/stepper';
import { SetupComponent } from './settings/setup/setup.component';


@NgModule({
  declarations: [
    InternshipListingComponent,
    MentorshipsComponent,
    SetupStepComponent,
    TrainersStepComponent,
    InternsStepComponent,
    MentorshipsStepComponent,
    InternshipWizardDialogComponent,
    SetupComponent,
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
    MatStepperModule
  ],
  exports: [
    SetupStepComponent, 
    TrainersStepComponent, 
    InternsStepComponent, 
    MentorshipsStepComponent
  ],
  providers: [

  ]
})
export class InternshipHubModule { }
