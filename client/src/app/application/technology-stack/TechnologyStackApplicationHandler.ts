import { Observable } from "rxjs";
import { TechnologyStack } from "src/app/domain/internship-hub/technologyStack/TechnologyStack";
import { ITechnologyStackApplicationHandler } from "./ITechnologyStackApplicationHandler";
import { ITechnologyStackService } from "../service/ITechnologyStackService";
import { Injectable } from "@angular/core";


@Injectable({
    providedIn: 'root'
  })
export class TechnologyStackApplicationHandler implements ITechnologyStackApplicationHandler {
    public constructor(private service: ITechnologyStackService) {}

    public getAllTechnologyStack(): Observable<TechnologyStack[]> {
        return this.service.getAllTechnologies()
    }
}