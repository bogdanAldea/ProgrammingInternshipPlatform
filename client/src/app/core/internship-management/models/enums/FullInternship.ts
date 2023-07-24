import { FullInternshipResponse } from "../../contracts/responses/FullInternshipResponse";
import { StatusFromResponse } from "./StatusFromResponse";
import { StatusToRequest } from "./StatusToRequest";

export class FullInternship
{
    public id: string;
    public status: string;
    public maximumInternsToEnroll: number;
    public durationInMonths: number;
    public scheduledToStartOn: Date;
    public scheduledToEndOn: Date;
    public center: string;

    public constructor(response: FullInternshipResponse) {
        this.id = response.id;
        this.status = this.setStatusName(response.status);
        this.maximumInternsToEnroll = response.maximumInternsToEnroll;
        this.durationInMonths = response.durationInMonths;
        this.scheduledToStartOn = response.scheduledToStartOn;
        this.scheduledToEndOn = response.scheduledToEndOn;
        this.center = response.center;
    }

    private setStatusName = (status: number): string => {
        switch (status) {
            case StatusFromResponse.setupInProgress:
                return StatusToRequest.setupInProgress;

            case StatusFromResponse.notStarted:
                return StatusToRequest.notStarted;

            case StatusFromResponse.ongoing:
                return StatusToRequest.ongoing;

            case StatusFromResponse.completed:
                return StatusToRequest.completed;

            default:
                return 'Unknown';
        }
    }
}