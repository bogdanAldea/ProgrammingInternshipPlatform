import { Component, Input } from '@angular/core';
import { IconRegistrar } from 'src/app/views/application-configs/icon-registrar/IconRegistrar';

@Component({
  selector: 'app-setup-step',
  templateUrl: './setup-step.component.html',
  styleUrls: ['./setup-step.component.scss']
})
export class SetupStepComponent {
  @Input() stepTitle: string | undefined;
  @Input() icons = IconRegistrar;
}
