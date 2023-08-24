import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IInternshipApplicationHandler } from 'src/app/application/internship-hub/handler/IInternshipApplicationHandler';
import { InternshipSetupRequest } from 'src/app/domain/internship-hub/internships/InternshipSetupRequest';
import { PartialInternship } from 'src/app/domain/internship-hub/internships/PartialInternship';

@Injectable({
  providedIn: 'root'
})
export class InternshipsHubControllerService {

  constructor(private internshipHandler: IInternshipApplicationHandler) { }

  public getAllInternships = (): Observable<PartialInternship[]> => {
    return this.internshipHandler.getAllInternships();
  }

  public createInternshipSetup = (request: InternshipSetupRequest): Observable<string> => {
    return this.internshipHandler.createInternshipSetup(request);
  }
}
