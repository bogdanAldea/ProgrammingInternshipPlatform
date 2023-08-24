import { Observable } from "rxjs";
import { InternshipSetupRequest } from "src/app/domain/internship-hub/internships/InternshipSetupRequest";
import { PartialInternship } from "src/app/domain/internship-hub/internships/PartialInternship";

export abstract class IInternshipService {
    abstract getAllInternshipPrograms(): Observable<PartialInternship[]>;
    abstract createInternshipSetup(request: InternshipSetupRequest): Observable<string>;
}