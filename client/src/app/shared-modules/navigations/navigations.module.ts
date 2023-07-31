import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserControlsNavigationComponent } from './user-controls-navigation/user-controls-navigation.component';
import { NavigationMenuComponent } from './navigation-menu/navigation-menu.component';
import { RouterModule } from '@angular/router';
import { NavLinkComponent } from './nav-link/nav-link.component';



@NgModule({
  declarations: [
    UserControlsNavigationComponent,
    NavigationMenuComponent,
    NavLinkComponent
  ],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [
    UserControlsNavigationComponent,
    NavigationMenuComponent
  ]
})
export class NavigationsModule { }
