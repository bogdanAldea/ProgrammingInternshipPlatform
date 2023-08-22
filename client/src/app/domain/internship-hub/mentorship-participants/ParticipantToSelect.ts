export interface ParticipantToSelectResponse {
    firstName: string;
    lastName: string;
    email: string;
    role: string;
    pictureUrl: string;
}

export class ParticipantToSelect {
    public fullName: string;
    public role: string;
    public email: string;
    public pictureUrl: string;

    public constructor(response: ParticipantToSelectResponse) {
        this.fullName = `${response.firstName} ${response.lastName}`;
        this.role = response.role;
        this.email = response.email;
        this.pictureUrl = response.pictureUrl;
    }
}