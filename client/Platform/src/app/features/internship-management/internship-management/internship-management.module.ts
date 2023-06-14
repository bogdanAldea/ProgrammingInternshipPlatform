import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InternshipListViewComponent } from '../internship-list-view/component/internship-list-view.component';
import { InternshipDetailViewComponent } from '../internship-detail-view/internship-detail-view.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    InternshipListViewComponent,
    InternshipDetailViewComponent
  ],
  imports: [
    CommonModule,
    RouterModule
  ]
})
export class InternshipManagementModule { }
