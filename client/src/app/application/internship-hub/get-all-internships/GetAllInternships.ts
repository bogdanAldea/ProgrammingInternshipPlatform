import { Observable } from "rxjs";
import { PartialInternship } from "src/app/domain/internship-hub/internships/PartialInternship";
import { IGEtAllInternships } from "./IGetAllInternships";
import { Injectable } from "@angular/core";
import { IInternshipService } from "../service/IInternshipService";

@Injectable({
    providedIn: 'root'
  })
export class GetAllInternships implements IGEtAllInternships{
    public constructor(private service: IInternshipService) {}

    execute(): Observable<PartialInternship[]> {
        return this.service.getAllInternshipPrograms();
    }
}