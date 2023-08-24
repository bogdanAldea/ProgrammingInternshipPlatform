import { Observable } from "rxjs";
import { Center } from "src/app/domain/internship-hub/centers/center";

export abstract class ICenterService {
    abstract getAllServices(): Observable<Center[]>;
}