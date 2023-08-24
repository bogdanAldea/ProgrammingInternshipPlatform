export interface BaseEnumResponse {
    value: number;
    name: string;
}

export class BaseEnumEntity {
    public value: number;
    public name: string;

    public constructor(response: BaseEnumResponse) {
        this.value = response.value;
        this.name = response.name
    }
}