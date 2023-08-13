import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActionCardComponent } from './action-card/action-card.component';



@NgModule({
  declarations: [
    ActionCardComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    ActionCardComponent
  ]
})
export class ActionCardsModule { }
