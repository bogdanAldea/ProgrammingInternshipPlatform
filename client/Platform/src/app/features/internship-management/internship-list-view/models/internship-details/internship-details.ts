import { InternshipStatus } from "../../../enums/internship-status";
import {InternshipDetailResponse} from "../../contracts/responses/internship-details/internship-detail-response";

export class InternshipDetails 
{
    public id: string;
    public status: string;
    public numberOfInterns: number;
    public maximumInternsToEnroll: number;
    public durationInMonths: number;
    public scheduledToStartOn: Date;
    public scheduledToEndOn: Date;

    constructor(internship: InternshipDetailResponse) 
    {
        this.id = internship.id;
        this.status = this.getStatusName(internship.status);
        this.numberOfInterns = internship.numberOfInterns;
        this.maximumInternsToEnroll = internship.maximumInternsToEnroll;
        this.durationInMonths = internship.durationInMonths;
        this.scheduledToStartOn = internship.scheduledToStartOn;
        this.scheduledToEndOn = internship.scheduledToEndOn;
    }

    private getStatusName = (status: number): string => {
        switch (status) {
            case InternshipStatus.setupInProgress:
              return 'Setup In Progress';
            case InternshipStatus.notStarted:
              return 'Not Started';
            case InternshipStatus.ongoing:
              return 'Ongoing';
            case InternshipStatus.completed:
              return 'Completed';
            default:
              return 'Unknown';
          }
    }
}
