import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { InternshipOptionsNodes } from 'src/app/shared/configurations/menuNodes';

@Component({
  selector: 'internship-hub-detail.page',
  templateUrl: './internship-hub-detail.page.component.html',
  styleUrls: ['./internship-hub-detail.page.component.scss']
})
export class InternshipHubDetailPage {
  public internshipOptions = InternshipOptionsNodes.ForAdministrator;
  public currentInternshipId: string | null;

  public constructor(private readonly route: ActivatedRoute) {
    this.currentInternshipId = this.route.snapshot.paramMap.get('id')
    console.log(this.currentInternshipId)
  }
}
