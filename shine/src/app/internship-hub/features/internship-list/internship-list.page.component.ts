import { Component, OnInit } from '@angular/core';
import { InternshipService } from '../../services/internship/internship.service';
import { InternshipWithCoordinator } from '../../models/internshipWithCoordinator';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'internship-list.page',
  templateUrl: './internship-list.page.component.html',
  styleUrls: ['./internship-list.page.component.scss']
})
export class InternshipListPage implements OnInit {
  public spinnerIsLoading: boolean = false;
  public internshipPrograms: InternshipWithCoordinator[] | undefined;
  
  public constructor(private readonly service: InternshipService, private route: ActivatedRoute) {}

  public ngOnInit(): void {
    this.spinnerIsLoading = true;
    this.service.getAllInternshipPrograms()
      .subscribe(data => {
        this.spinnerIsLoading = false;
        this.internshipPrograms = data
      })
  }

}
