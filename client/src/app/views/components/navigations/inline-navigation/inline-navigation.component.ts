import { Component, Input } from '@angular/core';
import { AuthenticationService } from 'src/app/services/authentication/authentication.service';
import { MenuItem } from 'src/app/views/application-configs/app-menu/MenuItem';

@Component({
  selector: 'app-inline-navigation',
  templateUrl: './inline-navigation.component.html',
  styleUrls: ['./inline-navigation.component.scss']
})
export class InlineNavigationComponent {
  @Input() menu: MenuItem[] | undefined;

  public constructor(private auth: AuthenticationService) {}
  
  public logout = () => {
    this.auth.logout
  }
}
