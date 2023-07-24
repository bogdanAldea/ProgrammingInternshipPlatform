import { Component } from '@angular/core';
import { Options } from './configurations/options';

@Component({
  selector: 'app-internship-options',
  templateUrl: './internship-options.component.html',
  styleUrls: ['./internship-options.component.scss']
})
export class InternshipOptionsComponent {
  public configurations = Options.Configurations;
  public members = Options.Members;
  public collaboration = Options.Collaboration;
}
