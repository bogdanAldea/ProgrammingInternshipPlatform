import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OptionsComponent } from './options/options.component';
import { SharedModule } from 'src/app/shared/shared.module';



@NgModule({
  declarations: [
    OptionsComponent,
  ],
  imports: [
    CommonModule,
    SharedModule
  ]
})
export class InternshipOptionsModule { }
