import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-setup-step',
  templateUrl: './setup-step.component.html',
  styleUrls: ['./setup-step.component.scss']
})
export class SetupStepComponent {
  @Input() stepTitle: string | undefined;
}
