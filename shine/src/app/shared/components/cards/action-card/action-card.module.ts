import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActionCard } from './action-card/action-card.component';



@NgModule({
  declarations: [
    ActionCard
  ],
  imports: [
    CommonModule
  ],
  exports: [ActionCard]
})
export class ActionCardModule { }
