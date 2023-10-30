import { Component, Input } from '@angular/core';

@Component({
  selector: 'initials-avatar',
  templateUrl: './initials-avatar.component.html',
  styleUrls: ['./initials-avatar.component.scss']
})
export class InitialsAvatar {
  @Input() public initials: string | undefined;
}
