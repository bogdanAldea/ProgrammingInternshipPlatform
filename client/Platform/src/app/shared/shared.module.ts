import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavHeaderComponent } from './nav-header/nav-header.component';
import { ContextLayoutComponent } from './layouts/context-layout/context-layout.component';

@NgModule({
  declarations: [
    NavHeaderComponent,
    ContextLayoutComponent,
  ],
  imports: [
    CommonModule
  ],
  exports: [
    NavHeaderComponent,
    ContextLayoutComponent
  ]
})
export class SharedModule { }
