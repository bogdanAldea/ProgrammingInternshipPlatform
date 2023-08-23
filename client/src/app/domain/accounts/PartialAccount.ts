export interface PartialAccountResponse {
    id: string;
    displayName: string;
    email: string;
}

export class PartialAccount {
    public id: string;
    public displayName: string;
    public email: string;

    public constructor(response: PartialAccountResponse) {
        this.id = response.id;
        this.displayName = response.displayName;
        this.email = response.email
    }
}