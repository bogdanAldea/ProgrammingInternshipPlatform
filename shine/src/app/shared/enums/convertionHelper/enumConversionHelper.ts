import { ConvertedFromEnum } from "../../models/convertedFromEnum";

export class EnumToListConverter {
    private static convertedValues: ConvertedFromEnum[] = [];
    
    public static convert<TEnum>(enumToConvert: Record<string, TEnum>): ConvertedFromEnum[] {
      for (const key of Object.keys(enumToConvert)) {
        const value = enumToConvert[key];
        if (!isNaN(Number(value))) {
          const name = this.convertToName(key)
          this.addConverted({ name, value: value as number });
        }
      }
      return this.convertedValues;
    }

    private static convertToName = (key: string) => {
        return key.replace(/([a-z])([A-Z])/g, '$1 $2');
    }

    private static addConverted = (converted: ConvertedFromEnum): void => {
        EnumToListConverter.convertedValues.push(converted)
    }
        
  }