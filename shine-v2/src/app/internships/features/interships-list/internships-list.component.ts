import { Component, OnInit } from '@angular/core';
import { InternshipService } from '../../data-access/internship.service';
import { InternshipQueryParams } from '../../data-access/internshipQueryParams';
import { Observable } from 'rxjs';

@Component({
  selector: 's-internships-list',
  templateUrl: './internships-list.component.html',
  styleUrls: ['./internships-list.component.scss']
})
export class InternshipsListComponent implements OnInit {
  public internshipsResult$: Observable<any> | undefined;
  
  public constructor(private readonly internshipService: InternshipService) {}
  
  public ngOnInit(): void {
    this.internshipsResult$ = this.getAllInternshipPrograms();
  }

  private getAllInternshipPrograms = (): Observable<any> => {
    const params: InternshipQueryParams = {
      internshipStatus: undefined, 
      estimatedGraduationDate: undefined, 
      scheduledStartDate: undefined,
      page: 1,
      resultsPerPage: 5
    };
    return this.internshipService.getAllInternshipPrograms(params);
  }
}
