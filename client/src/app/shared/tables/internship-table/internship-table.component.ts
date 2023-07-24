import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { FullInternship } from 'src/app/core/internship-management/models/enums/FullInternship';
import { StatusToRequest } from 'src/app/core/internship-management/models/enums/StatusToRequest';

@Component({
  selector: 'app-internship-table',
  templateUrl: './internship-table.component.html',
  styleUrls: ['./internship-table.component.scss']
})
export class InternshipTableComponent {
  public status = StatusToRequest;
  @Input() internships$: Observable<FullInternship[]> | undefined;
  @Output() onInternshipSelectedEvent: EventEmitter<any> = new EventEmitter<any>();
}
