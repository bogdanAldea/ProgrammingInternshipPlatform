import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InlineNavbar } from './inline-navbar/inline-navbar.component';
import { NodeModule } from '../node/node.module';
import { AvatarsModule } from '../../avatars/avatars.module';

@NgModule({
  declarations: [
    InlineNavbar
  ],
  imports: [
    CommonModule,
    NodeModule,
    AvatarsModule
  ],
  exports: [
    InlineNavbar
  ]
})
export class InlineNavbarModule { }
