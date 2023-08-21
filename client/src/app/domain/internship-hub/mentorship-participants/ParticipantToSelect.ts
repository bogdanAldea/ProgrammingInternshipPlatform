export interface ParticipantToSelectResponse {
    firstName: string;
    lastName: string;
    role: string;
    pictureUrl: string;
}

export class ParticipantToSelect {
    public fullName: string;
    public role: string;
    public pictureUrl: string;

    public constructor(response: ParticipantToSelectResponse) {
        this.fullName = `${response.firstName} ${response.lastName}`;
        this.role = response.role;
        this.pictureUrl = response.pictureUrl;
    }
}