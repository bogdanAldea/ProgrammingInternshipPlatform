import { Account, AccountWithPicture } from "src/app/shared/models/account";

export interface MemberServerResponse extends AccountWithPicture {
}

export class Member {
    public coordinatorId: string;
    public displayName: string;
    public givenName: string;
    public surname: string;
    public initials: string;
    public jobTitle: string;
    public email: string;
    public shortenedEmail: string;
    public pictureUrl?: string;
    public role: string;

    private constructor(response: MemberServerResponse) {
        this.coordinatorId = response.coordinatorId;
        this.displayName = response.displayName;
        this.givenName = response.givenName;
        this.surname = response.surname;
        this.initials = response.initials;
        this.jobTitle = response.jobTitle;
        this.email = response.email;
        this.shortenedEmail = response.shortenedEmail;
        this.pictureUrl = response.pictureUrl;
        this.role = response.role;
    }

    public static createFromResponse = (response: MemberServerResponse): Member => 
        new Member(response);
}