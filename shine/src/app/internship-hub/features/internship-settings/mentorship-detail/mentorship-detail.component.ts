import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { MentorshipPair } from 'src/app/internship-hub/models/mentorshipPair';
import { InternshipService } from 'src/app/internship-hub/services/internship/internship.service';
import { BasePage } from 'src/app/shared/components/abstracts/basePage';

@Component({
  selector: 'mentorship-detail',
  templateUrl: './mentorship-detail.component.html',
  styleUrls: ['./mentorship-detail.component.scss']
})
export class MentorshipDetailComponent extends BasePage implements OnInit {
  public isPageLoading: boolean = false;
  public internshipId: string | undefined;
  public mentorshipPairId: string | undefined;
  public mentorshipPair: MentorshipPair | undefined;
  private currentRoute!: ActivatedRoute;
  public addItem: string = '../../../../../assets/icons/light/Global/Internship.svg'
  public requestTransfer: string = '../../../../../assets/icons/light/Global/Transfer.svg'
  public provideFeedback: string = '../../../../../assets/icons/light/Global/Feedback.svg'

  public constructor(
    router: ActivatedRoute, 
    private readonly internshipService: InternshipService)
  { 
    super(router)
    this.currentRoute = router; 
  }

  public ngOnInit(): void {
    this.isPageLoading = true;
    this.internshipId = this.getParentIdFromRoute();
    this.mentorshipPairId = this.getMentorshipPairId();

    if (this.parentIdExistsOnRoute(this.internshipId) && this.parentIdExistsOnRoute(this.mentorshipPairId))
    {
      this.getMentorshipPair(this.internshipId!, this.mentorshipPairId!)
      .subscribe((response: MentorshipPair) => {
        this.mentorshipPair = response
        this.isPageLoading = false;
      })
    }
  }

  private getMentorshipPair = (internshipId: string, mentorshipId: string): Observable<MentorshipPair> =>
    this.internshipService.getMentorshipPair(internshipId, mentorshipId)
  
  private getMentorshipPairId = () => this.currentRoute.snapshot.params['mentorshipId'];
}

