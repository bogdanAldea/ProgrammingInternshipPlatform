import { ModalAction } from "./modalAction";

export class ModalResult<TPayload> {
    public readonly result: ModalAction;
    public readonly payload?: TPayload;

    private constructor(result: ModalAction, payload?: TPayload)
    {
        this.result = result;
        this.payload = payload;
    }

    public static createOkAction = <TPayload>(value: TPayload): ModalResult<TPayload> => 
        new ModalResult(ModalAction.Ok, value);

    public static createCancelAction = <TPayload>(): ModalResult<TPayload> => 
        new ModalResult(ModalAction.Cancel);
}