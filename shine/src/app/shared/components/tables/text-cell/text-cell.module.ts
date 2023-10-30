import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TextCell } from './text-cell/text-cell.component';



@NgModule({
  declarations: [
    TextCell
  ],
  imports: [
    CommonModule
  ],
  exports: [TextCell]
})
export class TextCellModule { }
