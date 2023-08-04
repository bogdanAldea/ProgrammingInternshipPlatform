import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavigationLayoutComponent } from './navigation-layout/navigation-layout.component';
import { NavigationsModule } from '../navigations/navigations.module';
import { RouterModule } from '@angular/router';
import { NoNavLayoutComponent } from './no-nav-layout/no-nav-layout.component';



@NgModule({
  declarations: [
    NavigationLayoutComponent,
    NoNavLayoutComponent
  ],
  imports: [
    CommonModule,
    NavigationsModule,
    RouterModule,
  ]
})
export class LayoutsModule { }
