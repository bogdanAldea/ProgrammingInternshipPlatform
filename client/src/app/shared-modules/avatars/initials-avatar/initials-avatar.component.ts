import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-initials-avatar',
  templateUrl: './initials-avatar.component.html',
  styleUrls: ['./initials-avatar.component.scss']
})
export class InitialsAvatarComponent {
  @Input() public first: string | undefined;
  @Input() public second: string | undefined;
}
