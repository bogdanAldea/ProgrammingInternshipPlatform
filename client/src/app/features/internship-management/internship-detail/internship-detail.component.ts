import { Component } from '@angular/core';
import { Settings } from 'src/app/configurations/internship-settings/settings';

@Component({
  selector: 'app-internship-detail',
  templateUrl: './internship-detail.component.html',
  styleUrls: ['./internship-detail.component.scss']
})
export class InternshipDetailComponent {
  public configurations = Settings.Configurations;
  public members = Settings.Members;
  public collaboration = Settings.Collaboration;
}
