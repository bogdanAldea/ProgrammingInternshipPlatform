import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InternshipListViewComponent } from '../internship-list-view/component/internship-list-view.component';
import { InternshipDetailViewComponent } from '../internship-detail-view/internship-detail-view.component';
import { RouterModule } from '@angular/router';
import { InternshipTableComponent } from '../internship-list-view/component/internship-table/internship-table.component';



@NgModule({
  declarations: [
    InternshipListViewComponent,
    InternshipDetailViewComponent,
    InternshipTableComponent
  ],
  imports: [
    CommonModule,
    RouterModule
  ]
})
export class InternshipManagementModule { }
