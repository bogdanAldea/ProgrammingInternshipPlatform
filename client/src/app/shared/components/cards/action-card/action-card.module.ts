import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActionCard } from './action-card.component';
import { ActionButtonModule } from '../../buttons/action-button/action-button.module';


@NgModule({
  declarations: [
    ActionCard
  ],
  imports: [
    CommonModule,
    ActionButtonModule
  ],
  exports: [ActionCard]
})
export class ActionCardModule { }
