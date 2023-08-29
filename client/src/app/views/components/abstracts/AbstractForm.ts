import { Observable } from "rxjs";
import { FieldType } from "../../helpers/FieldType";
import { EventEmitter, Injectable, Output } from "@angular/core";

export interface AbstractForm {
    isRequired: boolean | undefined;
    validateForm(): boolean;
    getFilledDate(): {[key: string]: any};
    createRequestData(requestData: { [key: string]: any }): any;
    sendRequest(request: any) : Observable<any>
}

@Injectable({
    providedIn: 'root'
  })
export abstract class AbstractNotifier {
    @Output() requestMarkedAsReady: EventEmitter<void> = new EventEmitter();
    public notifyRequestReady = (): void => this.requestMarkedAsReady.emit();
}