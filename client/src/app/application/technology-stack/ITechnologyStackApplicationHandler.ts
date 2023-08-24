import { Observable } from "rxjs";
import { TechnologyStack } from "src/app/domain/internship-hub/technologyStack/TechnologyStack";

export abstract class ITechnologyStackApplicationHandler{
    abstract getAllTechnologyStack(): Observable<TechnologyStack[]>;
}