import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InternshipListComponent } from './internship-list/internship-list.component';
import { InternshipTableComponent } from './internship-table/internship-table.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    InternshipListComponent,
    InternshipTableComponent
  ],
  imports: [
    CommonModule,
    RouterModule
  ]
})
export class InternshipListingModule { }
