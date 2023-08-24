export interface AbstractForm {
    readonly isRequired: boolean;
    validateForm(): boolean;
    getFilledDate(): {[key: string]: any};
}