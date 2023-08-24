import { FieldType } from "./FieldType";

export class FieldValueConverter {
    public static convertValue = (value: string, valueType: any): any => {
        switch (valueType) {
            case FieldType.int:
                return parseInt(value);
            case FieldType.float:
                return parseFloat(value);
            case FieldType.date:
                return new Date(value);
        }
    }

    public static toDate = (value: string): Date | undefined => value === undefined ? undefined : new Date(value);
}