import { Component, Input } from '@angular/core';
import { IconRegistrar } from 'src/app/views/application-configs/icon-registrar/IconRegistrar';

@Component({
  selector: 'app-trainers-step',
  templateUrl: './trainers-step.component.html',
  styleUrls: ['./trainers-step.component.scss']
})
export class TrainersStepComponent {
  @Input() stepTitle: string | undefined;
  @Input() icons = IconRegistrar;
}
