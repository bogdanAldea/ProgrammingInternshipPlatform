import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavigationLayoutComponent } from './navigation-layout/navigation-layout.component';
import { NavigationsModule } from '../navigations/navigations.module';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    NavigationLayoutComponent
  ],
  imports: [
    CommonModule,
    NavigationsModule,
    RouterModule
  ]
})
export class LayoutsModule { }
