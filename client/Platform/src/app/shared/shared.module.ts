import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavHeaderComponent } from './nav-header/nav-header.component';
import { ContextLayoutComponent } from './layouts/context-layout/context-layout.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    NavHeaderComponent,
    ContextLayoutComponent,
  ],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [
    NavHeaderComponent,
    ContextLayoutComponent
  ]
})
export class SharedModule { }
