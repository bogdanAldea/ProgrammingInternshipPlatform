import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TargetDirective } from './target.directive';



@NgModule({
  declarations: [TargetDirective],
  imports: [
    CommonModule
  ],
  exports:[TargetDirective]
})
export class TargetModule { }
