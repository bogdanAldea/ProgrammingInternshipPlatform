import { Component, Input } from '@angular/core';
import { Setting } from 'src/app/configurations/internship-settings/setting';

@Component({
  selector: 'app-internship-option-card',
  templateUrl: './internship-option-card.component.html',
  styleUrls: ['./internship-option-card.component.scss']
})
export class InternshipOptionCardComponent {
  @Input() setting!: Setting
}
