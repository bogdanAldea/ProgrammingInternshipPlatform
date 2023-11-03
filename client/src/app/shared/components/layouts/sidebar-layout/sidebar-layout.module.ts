import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SidebarLayout } from './sidebar-layout.component';
import { TopbarModule } from '../../navigations/topbar/topbar.module';
import { SidebarModule } from '../../navigations/sidebar/sidebar.module';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    SidebarLayout
  ],
  imports: [
    CommonModule,
    TopbarModule,
    SidebarModule,
    RouterModule
  ],
  exports: [SidebarLayout]
})
export class SidebarLayoutModule { }
