import { Center } from "./Center";
import { Status } from "./Status";

export interface PartialInternshipResponse {
    id: string;
    status: number;
    center: number;
    maxInternsToEnroll: number;
    durationInMonths: number;
    scheduledToStartOn: Date;
    estimatedToEndOn: Date;
}

export class PartialInternship {
    public constructor(response: PartialInternshipResponse){
        this.id = response.id;
        this.status = this.convertStatus(response.status);
        this.center = this.convertCenter(response.center)
        this.maxInternsToEnroll = response.maxInternsToEnroll;
        this.durationInMonths = response.durationInMonths;
        this.scheduledToStartOn = response.scheduledToStartOn;
        this.estimatedToEndOn = response.estimatedToEndOn;
    }

    public id: string;
    public status: string;
    public center: string;
    public maxInternsToEnroll: number;
    public durationInMonths: number;
    public scheduledToStartOn: Date;
    public estimatedToEndOn: Date;

    private convertStatus = (status: number) : string => {
        switch (status) {
            case Status.SetupInProgress:
                return 'Setup In Progress';
            case Status.ReadyToStart:
                return 'Ready To Start';
            case Status.Published:
                return 'Published';
            case Status.Abandoned:
                return 'Abandoned';
            case Status.Ongoing:
                return 'Ongoing';
            case Status.Postponed:
                return 'Postponed';
            case Status.Completed:
                return 'Completed'
            default:
                return '';
        }
    }

    private convertCenter = (center: number) : string => {
        switch (center) {
            case Center.Romania:
                return 'Romania';
            case Center.England:
                return 'England';
            case Center.Hungary:
                return 'Hungary';
            case Center.Norway:
                return 'Norway';
            case Center.Serbia:
                return 'Serbia'
            default:
                return '';
        }
    }
}