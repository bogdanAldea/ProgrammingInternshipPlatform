import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { InternshipWithCoordinator } from '../../models/internshipWitCoordinator';
import { InternshipHubService } from '../../data-access/internship-hub-service.service';
import { InternshipQueryParams } from '../../models/queryParams';
import { MatDialog } from '@angular/material/dialog';
import { GenericDialog } from 'src/app/shared/components/dialogs/generic-dialog/generic-dialog.component';
import { DialogOptions } from 'src/app/shared/components/dialogs/generic-dialog/dialogTypes';

@Component({
  selector: 'internship-hub-list.page',
  templateUrl: './internship-hub-list.page.component.html',
  styleUrls: ['./internship-hub-list.page.component.scss']
})
export class InternshipHubListPage implements OnInit {
  public isLoading: boolean = true;
  public internships$: Observable<ReadonlyArray<InternshipWithCoordinator>> | undefined;
  public hasInternships: boolean = false;

  public constructor(
    private readonly internshipHubService: InternshipHubService,
    private readonly dialog: MatDialog) {}

  public ngOnInit(): void {
    this.internships$ = this.getAllInternshipPrograms();
    this.internships$.subscribe((internships: ReadonlyArray<any>) => {
      this.isLoading = false;
      this.hasInternships = internships.length > 0
    })
  }

  public scheduleInternship = () => {
    //
  }

  private getAllInternshipPrograms = (): Observable<ReadonlyArray<InternshipWithCoordinator>>  => {
    const params: InternshipQueryParams = {
      internshipStatus: undefined, 
      estimatedGraduationDate: undefined, 
      scheduledStartDate: undefined,
      page: 1,
      resultsPerPage: 10
    };

    const internshipsResponse = this.internshipHubService.getAllInternshipProgramsAtOrganisation(params);
    return internshipsResponse;
  }

  private createDialogData = (): DialogOptions<string> => {
    return {
      header: {
        title: 'Schedule new internship',
        description: 'Choose which options will fit your needs at the moment.'
      },
      body: undefined,
      actions: []
    }
  }
}
