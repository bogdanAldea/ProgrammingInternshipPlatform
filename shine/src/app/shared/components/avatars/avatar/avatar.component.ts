import { Component, Input } from '@angular/core';

@Component({
  selector: 'avatar',
  templateUrl: './avatar.component.html',
  styleUrls: ['./avatar.component.scss']
})
export class Avatar {
  @Input() public pictureUrl: string | undefined;
  @Input() public width: string = '30px'
  @Input() public height: string = '30px';
}
