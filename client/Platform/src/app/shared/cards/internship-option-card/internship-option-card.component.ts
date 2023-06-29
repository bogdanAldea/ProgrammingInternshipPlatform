import { Component, Input } from '@angular/core';
import { Option } from 'src/app/core/option';
import { Options } from 'src/app/core/options';

@Component({
  selector: 'app-internship-option-card',
  templateUrl: './internship-option-card.component.html',
  styleUrls: ['./internship-option-card.component.scss']
})
export class InternshipOptionCardComponent {
  @Input() option!: Option;
  @Input() internshipId!: string;
}
