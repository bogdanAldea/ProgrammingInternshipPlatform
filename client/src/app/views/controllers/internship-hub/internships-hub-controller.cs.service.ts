import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IInternshipApplicationHandler } from 'src/app/application/internship-hub/handler/IInternshipApplicationHandler';
import { ITechnologyStackApplicationHandler } from 'src/app/application/technology-stack/ITechnologyStackApplicationHandler';
import { InternshipSetupRequest } from 'src/app/domain/internship-hub/internships/InternshipSetupRequest';
import { PartialInternship } from 'src/app/domain/internship-hub/internships/PartialInternship';
import { TrainerDelegateRequest } from 'src/app/domain/internship-hub/internships/TrainerDelegateRequest';
import { TechnologyStack } from 'src/app/domain/internship-hub/technologyStack/TechnologyStack';

@Injectable({
  providedIn: 'root'
})
export class InternshipsHubController {

  constructor(
    private internshipHandler: IInternshipApplicationHandler,
    private technologyStackHandler: ITechnologyStackApplicationHandler
    ) { }

  public getAllInternships = (): Observable<PartialInternship[]> => {
    return this.internshipHandler.getAllInternships();
  }

  public createInternshipSetup = (request: InternshipSetupRequest): Observable<string> => {
    return this.internshipHandler.createInternshipSetup(request);
  }

  public getAllTechnologies = (): Observable<TechnologyStack[]> => {
    return this.technologyStackHandler.getAllTechnologyStack();
  }

  public delegateTrainer = (internshipId: string, request: TrainerDelegateRequest): Observable<any> => {
    return this.internshipHandler.delegateTrainer(internshipId, request);
  }
}
