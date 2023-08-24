import { Component } from '@angular/core';
import { IconRegistrar } from 'src/app/views/application-configs/icon-registrar/IconRegistrar';

@Component({
  selector: 'app-setup-form',
  templateUrl: './setup-form.component.html',
  styleUrls: ['./setup-form.component.scss']
})
export class SetupFormComponent {
  public icons = IconRegistrar;
}
