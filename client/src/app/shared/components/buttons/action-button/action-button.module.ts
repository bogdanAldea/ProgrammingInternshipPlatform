import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActionButton } from './action-button.component';


@NgModule({
  declarations: [
    ActionButton
  ],
  imports: [
    CommonModule
  ],
  exports: [ActionButton]
})
export class ActionButtonModule { }
