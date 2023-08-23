import { Observable } from "rxjs";
import { PartialInternship } from "src/app/domain/internship-hub/internships/PartialInternship";

export abstract class IInternshipApplicationHandler {
    abstract getAllInternships(): Observable<PartialInternship[]>;
}