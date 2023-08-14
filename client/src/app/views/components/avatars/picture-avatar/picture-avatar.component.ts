import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-picture-avatar',
  templateUrl: './picture-avatar.component.html',
  styleUrls: ['./picture-avatar.component.scss']
})
export class PictureAvatarComponent {
  @Input() public pictureUrl: string | undefined;
  @Input() public width: string = '30px'
  @Input() public height: string = '30px';
}
