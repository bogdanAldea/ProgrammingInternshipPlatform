import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavHeaderComponent } from './nav-header/nav-header.component';
import { ContextLayoutComponent } from './layouts/context-layout/context-layout.component';
import { RouterModule } from '@angular/router';
import { InternshipOptionCardComponent } from './cards/internship-option-card/internship-option-card.component';

@NgModule({
  declarations: [
    NavHeaderComponent,
    ContextLayoutComponent,
    InternshipOptionCardComponent,
  ],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [
    NavHeaderComponent,
    ContextLayoutComponent,
    InternshipOptionCardComponent
  ]
})
export class SharedModule { }
