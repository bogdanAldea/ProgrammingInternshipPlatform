
import { Observable } from "rxjs";
import { Center } from "src/app/domain/internship-hub/centers/center";
import { ICenterService } from "../../service/ICenterService";
import { Injectable } from "@angular/core";
import { ICenterApplicationHandler } from "./ICenterApplicationHandler";

@Injectable({
    providedIn: 'root'
  })
export class CenterApplicationHandler implements ICenterApplicationHandler{

    public constructor(private service: ICenterService) {}

    public getAllCenters = (): Observable<Center[]> => {
        return this.service.getAllServices();
    }
}