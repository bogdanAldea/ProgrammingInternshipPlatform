import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { InternshipWithCoordinator } from '../../models/internshipWitCoordinator';
import { InternshipHubService } from '../../data-access/internship-hub-service.service';
import { InternshipQueryParams } from '../../models/queryParams';

@Component({
  selector: 'internship-hub-list.page',
  templateUrl: './internship-hub-list.page.component.html',
  styleUrls: ['./internship-hub-list.page.component.scss']
})
export class InternshipHubListPage implements OnInit {
  public isLoading: boolean = true;
  public internships$: Observable<ReadonlyArray<InternshipWithCoordinator>> | undefined;
  public hasInternships: boolean = false;

  public constructor(private readonly internshipHubService: InternshipHubService) {}

  public ngOnInit(): void {
    this.internships$ = this.getAllInternshipPrograms();
    this.internships$.subscribe((internships: ReadonlyArray<any>) => {
      this.isLoading = false;
      this.hasInternships = internships.length > 0
    })
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

}
