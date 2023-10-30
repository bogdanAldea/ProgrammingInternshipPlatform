import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable, forkJoin } from 'rxjs';
import { InternshipService } from 'src/app/internship-hub/services/internship/internship.service';
import { BasePage } from 'src/app/shared/components/abstracts/basePage';
import { AccountWithPicture } from 'src/app/shared/models/account';
import { AccountsService } from 'src/app/shared/services/accounts/accounts.service';

@Component({
  selector: 'trainers',
  templateUrl: './trainers.component.html',
  styleUrls: ['./trainers.component.scss']
})
export class TrainersComponent extends BasePage implements OnInit {
  public trainers: AccountWithPicture[] | undefined;
  public isPageLoading: boolean = false;
  private internshipGuid: string | undefined;

  constructor(
    router: ActivatedRoute,
    private readonly internshipService: InternshipService,
    private readonly accountService: AccountsService
    ) { super(router) }

  public ngOnInit(): void {
    this.isPageLoading = true;
    this.internshipGuid = this.getParentIdFromRoute();
    
    if (this.parentIdExistsOnRoute(this.internshipGuid)) {
      const allTrainers = this.getAllTrainers();
      
      forkJoin([allTrainers]).subscribe(
        ([trainers]) => {
          this.trainers = trainers
          
        }
      )
      this.isPageLoading = false;
    }
  }

  private getAllTrainers = (): Observable<AccountWithPicture[]> =>
    this.accountService.getAccountsByRole('Trainer')
}
