import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { InternshipManagementService } from '../../../core/services/internship-management.service';
import { InternshipSettings } from '../../../core/models/internship-settings';
import { Observable, map, switchMap } from 'rxjs';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.scss']
})
export class SettingsComponent implements OnInit{
  internshipSettings$!: Observable<InternshipSettings>;
  internshipId!: string;
  constructor(private route: ActivatedRoute, private service: InternshipManagementService) {}
  
  ngOnInit(): void {
    this.internshipId = this.route.snapshot.params['id'];
    this.internshipSettings$ = this.service.getInternshipSettings(this.internshipId);
  }

}
