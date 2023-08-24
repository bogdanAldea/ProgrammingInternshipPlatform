import { Observable } from "rxjs";
import { FieldType } from "../../helpers/FieldType";

export interface AbstractForm {
    isRequired: boolean | undefined;
    validateForm(): boolean;
    getFilledDate(): {[key: string]: any};
    createRequestData(requestData: { [key: string]: any }): any;
    sendRequest(request: any) : Observable<any>
}