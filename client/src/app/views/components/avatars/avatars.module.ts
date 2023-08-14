import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PictureAvatarComponent } from './picture-avatar/picture-avatar.component';
import { InitialsAvatarComponent } from './initials-avatar/initials-avatar.component';

@NgModule({
  declarations: [
    PictureAvatarComponent,
    InitialsAvatarComponent,
  ],
  imports: [
    CommonModule,
  ],
  exports: [
    PictureAvatarComponent,
    InitialsAvatarComponent
  ]
})
export class AvatarsModule { }
