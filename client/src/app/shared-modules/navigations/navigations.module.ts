import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserControlsNavigationComponent } from './user-controls-navigation/user-controls-navigation.component';
import { NavigationMenuComponent } from './navigation-menu/navigation-menu.component';
import { RouterModule } from '@angular/router';
import { NavLinkComponent } from './nav-link/nav-link.component';
import { AvatarsModule } from '../avatars/avatars.module';
import {MatInputModule} from '@angular/material/input';




@NgModule({
  declarations: [
    UserControlsNavigationComponent,
    NavigationMenuComponent,
    NavLinkComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    AvatarsModule,
    MatInputModule
  ],
  exports: [
    UserControlsNavigationComponent,
    NavigationMenuComponent
  ]
})
export class NavigationsModule { }
