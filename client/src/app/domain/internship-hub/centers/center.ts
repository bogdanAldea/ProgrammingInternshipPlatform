export interface CenterResponse {
    value: number;
    name: string;
}

export class Center {
    public value: number;
    public name: string;

    public constructor(response: CenterResponse) {
        this.value = response.value;
        this.name = response.name
    }
}