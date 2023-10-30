import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Avatar } from './avatar/avatar.component';
import { InitialsAvatar } from './initials-avatar/initials-avatar.component';



@NgModule({
  declarations: [
    Avatar,
    InitialsAvatar
  ],
  imports: [
    CommonModule
  ],
  exports: [
    Avatar,
    InitialsAvatar
  ]
})
export class AvatarsModule { }
