import { Observable } from "rxjs";
import { PartialInternship } from "src/app/domain/internship-hub/internships/PartialInternship";
import { Injectable } from "@angular/core";
import { IInternshipService } from "../../service/IInternshipService";
import { IInternshipApplicationHandler } from "./IInternshipApplicationHandler";
import { InternshipSetupRequest } from "src/app/domain/internship-hub/internships/InternshipSetupRequest";

@Injectable({
    providedIn: 'root'
  })
export class InternshipApplicationHandler implements IInternshipApplicationHandler{
    public constructor(private service: IInternshipService) {}

    public getAllInternships(): Observable<PartialInternship[]> {
        return this.service.getAllInternshipPrograms();
    }

    public createInternshipSetup = (request: InternshipSetupRequest): Observable<string> => {
        return this.service.createInternshipSetup(request);
    }
}