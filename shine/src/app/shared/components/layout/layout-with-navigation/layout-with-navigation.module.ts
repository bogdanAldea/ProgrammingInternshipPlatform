import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutWithNavigation } from './layout-with-navigation/layout-with-navigation.component';
import { RouterModule } from '@angular/router';
import { InlineNavbarModule } from '../../navigations/inline-navbar/inline-navbar.module';



@NgModule({
  declarations: [
    LayoutWithNavigation
  ],
  imports: [
    CommonModule,
    RouterModule,
    InlineNavbarModule
  ],
})
export class LayoutWithNavigationModule { }
