import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { NavLinkComponent } from './nav-link/nav-link.component';
import { AvatarsModule } from '../avatars/avatars.module';
import {MatInputModule} from '@angular/material/input';
import { InlineNavigationComponent } from './inline-navigation/inline-navigation.component';




@NgModule({
  declarations: [
    NavLinkComponent,
    InlineNavigationComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    AvatarsModule,
    MatInputModule
  ],
  exports: [
    InlineNavigationComponent
  ]
})
export class NavigationsModule { }
