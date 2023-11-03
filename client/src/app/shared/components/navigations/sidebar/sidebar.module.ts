import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Sidebar } from './sidebar.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    Sidebar
  ],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [Sidebar]
})
export class SidebarModule { }
