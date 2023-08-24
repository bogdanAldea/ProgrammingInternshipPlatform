export interface AbstractForm {
    validateForm(): boolean;
    getFilledDate(): {[key: string]: any};
}