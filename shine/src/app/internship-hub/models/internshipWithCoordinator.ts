import { MemberServerResponse, Member,  } from "./member";
import { InternshipServerResponse, PartialInternship } from "./partialInternship";

export interface InternshipWithCoordinatorResponse {
    coordinator: MemberServerResponse;
    internship: InternshipServerResponse;
}

export class InternshipWithCoordinator {

    public coordinator: Member;
    public internship: PartialInternship;

    private constructor(response: InternshipWithCoordinatorResponse) {
        this.coordinator = Member.createFromResponse(response.coordinator);
        this.internship = PartialInternship.createFromResponse(response.internship);
    }

    public static createFromResponse = (response: InternshipWithCoordinatorResponse): InternshipWithCoordinator => 
        new InternshipWithCoordinator(response);

}