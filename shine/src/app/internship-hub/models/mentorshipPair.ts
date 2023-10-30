import { Account } from "src/app/shared/models/account";
import { Member } from "./member";

export interface MentorshipPairServerResponse {
    mentorshipPairId: string;
    trainer: Account;
    intern: Account;
}

export class MentorshipPair {
    public mentorshipPairId: string;
    public trainer: Member;
    public intern: Member;

    private constructor(serverResponse: MentorshipPairServerResponse) {
        this.mentorshipPairId = serverResponse.mentorshipPairId;
        this.trainer = Member.createFromResponse(serverResponse.trainer);
        this.intern = Member.createFromResponse(serverResponse.intern);
    }

    public static createFromResponse = (response: MentorshipPairServerResponse): MentorshipPair =>
         new MentorshipPair(response)
}