import { Observable } from "rxjs";
import { InternshipSetupRequest } from "src/app/domain/internship-hub/internships/InternshipSetupRequest";
import { PartialInternship } from "src/app/domain/internship-hub/internships/PartialInternship";
import { TrainerDelegateRequest } from "src/app/domain/internship-hub/internships/TrainerDelegateRequest";

export abstract class IInternshipApplicationHandler {
    abstract getAllInternships(): Observable<PartialInternship[]>;
    abstract createInternshipSetup(request: InternshipSetupRequest): Observable<string>;
    abstract delegateTrainer(internshipId: string, request: TrainerDelegateRequest): Observable<any>;
}