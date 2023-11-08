import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SidebarLayoutComponent } from './sidebar-layout.component';
import { TopbarModule } from '../../navigations/topbar/topbar.module';
import { SidebarModule } from '../../navigations/sidebar/sidebar.module';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    SidebarLayoutComponent
  ],
  imports: [
    CommonModule,
    TopbarModule,
    SidebarModule,
    RouterModule
  ]
})
export class SidebarLayoutModule { }
