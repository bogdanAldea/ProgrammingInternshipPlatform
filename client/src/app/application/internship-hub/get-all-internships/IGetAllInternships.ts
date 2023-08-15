import { Observable } from "rxjs";
import { PartialInternship } from "src/app/domain/internship-hub/internships/PartialInternship";

export abstract class IGEtAllInternships {
    abstract execute(): Observable<PartialInternship[]>;
}