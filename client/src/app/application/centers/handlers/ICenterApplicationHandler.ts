import { Observable } from "rxjs";
import { Center } from "src/app/domain/internship-hub/centers/center";

export abstract class ICenterApplicationHandler {
    abstract getAllCenters(): Observable<Center[]>;
}