import { Observable } from "rxjs";
import { TechnologyStack } from "src/app/domain/internship-hub/technologyStack/TechnologyStack";

export abstract class ITechnologyStackService {
    abstract getAllTechnologies(): Observable<TechnologyStack[]>;
}