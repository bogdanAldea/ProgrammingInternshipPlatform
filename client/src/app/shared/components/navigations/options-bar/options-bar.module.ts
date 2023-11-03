import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OptionsBar } from './options-bar.component';
import { LinkNodeModule } from '../link-node/link-node.module';



@NgModule({
  declarations: [
    OptionsBar
  ],
  imports: [
    CommonModule,
    LinkNodeModule
  ],
  exports: [OptionsBar]
})
export class OptionsBarModule { }
