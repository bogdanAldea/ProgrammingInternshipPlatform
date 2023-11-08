import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GenericDialog } from './generic-dialog.component';
import { ActionButtonModule } from '../../buttons/action-button/action-button.module';
import { TargetModule } from 'src/app/shared/directives/target/target.module';



@NgModule({
  declarations: [
    GenericDialog
  ],
  imports: [
    CommonModule,
    ActionButtonModule,
    TargetModule
  ],
  exports: [
    GenericDialog
  ]
})
export class GenericDialogModule { }