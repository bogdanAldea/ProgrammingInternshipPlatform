import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InternshipSettingsRoutingModule } from './internship-settings-routing.module';
import { SetupComponent } from './setup/setup.component';
import { TrainersComponent } from './trainers/trainers.component';
import { DatePickerModule } from 'src/app/shared/components/ranged-date-picker/date-picker.module';
import { DropdownSelectorModule } from 'src/app/shared/components/dropdown-selector/dropdown-selector.module';
import { SpinnerModule } from 'src/app/shared/components/spinners/spinner/spinner.module';
import { ActionButtonModule } from 'src/app/shared/components/buttons/action-button/action-button.module';
import { MentorshipComponent } from './mentorship/mentorship.component';
import { MentorshipDetailComponent } from './mentorship-detail/mentorship-detail.component';
import { TextCellModule } from 'src/app/shared/components/tables/text-cell/text-cell.module';
import { MentorshipMemberCardModule } from 'src/app/shared/components/cards/mentorship-member-card/mentorship-member-card.module';
import { ActionCardModule } from 'src/app/shared/components/cards/action-card/action-card.module';



@NgModule({
  declarations: [
    SetupComponent,
    TrainersComponent,
    MentorshipComponent,
    MentorshipDetailComponent, 
  ],
  imports: [
    ActionButtonModule,
    ActionCardModule,
    CommonModule,
    InternshipSettingsRoutingModule,
    DatePickerModule,
    DropdownSelectorModule,
    SpinnerModule,
    MentorshipMemberCardModule
  ]
})
export class InternshipSettingsModule { }
