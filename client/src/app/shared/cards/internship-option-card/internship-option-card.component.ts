import { Component, Input } from '@angular/core';
import { Option } from 'src/app/features/internship-management/internship-options/configurations/option';

@Component({
  selector: 'app-internship-option-card',
  templateUrl: './internship-option-card.component.html',
  styleUrls: ['./internship-option-card.component.scss']
})
export class InternshipOptionCardComponent {
  @Input() public option!: Option;
}
