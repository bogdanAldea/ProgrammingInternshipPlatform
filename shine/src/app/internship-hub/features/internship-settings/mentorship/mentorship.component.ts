import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { MentorshipPair, MentorshipPairServerResponse } from 'src/app/internship-hub/models/mentorshipPair';
import { CenterService } from 'src/app/internship-hub/services/center/center.service';
import { InternshipService } from 'src/app/internship-hub/services/internship/internship.service';
import { BasePage } from 'src/app/shared/components/abstracts/basePage';
import { CardRenderOptions } from 'src/app/shared/configurations/component-options/cardOptions';

@Component({
  selector: 'mentorship',
  templateUrl: './mentorship.component.html',
  styleUrls: ['./mentorship.component.scss']
})
export class MentorshipComponent extends BasePage implements OnInit {
  public mentorshipPairs: MentorshipPair[] | undefined;
  public internshipId: string | undefined;
  public cardOptions: CardRenderOptions = {
    height: '40px', width: '40px'
  }

  public constructor(
    router: ActivatedRoute, 
    private readonly internshipService: InternshipService) { super(router) }
  
  public ngOnInit(): void {
    this.internshipId = this.getParentIdFromRoute();
    
    if (this.parentIdExistsOnRoute(this.internshipId)) {
      this.getAllMentorshipPairs(this.internshipId!)
      .subscribe((response: MentorshipPair[]) => this.mentorshipPairs = response)
    }
  }

  private getAllMentorshipPairs = (internshipId: string): Observable<MentorshipPair[]> => 
    this.internshipService.getAllMentorshipPairs(internshipId);
}
