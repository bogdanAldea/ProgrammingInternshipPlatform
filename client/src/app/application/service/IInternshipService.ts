import { Observable } from "rxjs";
import { PartialInternship } from "src/app/domain/internship-hub/internships/PartialInternship";

export abstract class IInternshipService {
    abstract getAllInternshipPrograms(): Observable<PartialInternship[]>;
}