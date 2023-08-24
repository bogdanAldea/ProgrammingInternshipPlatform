import { FieldType } from "../../helpers/FieldType";

export interface InputOptions {
    type?: FieldType | string;
    identifier?: string;
    icon?: string;
    label?: string;
    selectedValue?: string;
}