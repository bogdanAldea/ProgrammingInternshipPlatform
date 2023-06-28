import { Component, OnInit } from '@angular/core';
import { InternshipManagementService } from '../../core/services/internship-management.service';
import { Internship } from '../../core/models/internship';

@Component({
  selector: 'app-internship-list',
  templateUrl: './internship-list.component.html',
  styleUrls: ['./internship-list.component.scss']
})
export class InternshipListComponent implements OnInit
{
  public internships: Internship[] | undefined;

  constructor(private service: InternshipManagementService) {}

  ngOnInit(): void 
  {
    this.service.getAllInternshipsAtOrganisation()
    .subscribe(internships => {
      this.internships = internships
      console.log(this.internships)
    });

  }
}
