import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DropdownSelector } from './dropdown-selector.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import {MatSelectModule} from '@angular/material/select';



@NgModule({
  declarations: [
    DropdownSelector
  ],
  imports: [
    CommonModule,
    MatFormFieldModule,
    MatSelectModule
  ],
  exports: [DropdownSelector]
})
export class DropdownSelectorModule { }
