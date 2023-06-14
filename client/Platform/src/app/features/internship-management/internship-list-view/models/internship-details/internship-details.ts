import {InternshipDetailResponse} from "../../contracts/responses/internship-details/internship-detail-response";

export class InternshipDetails 
{
    public id: string;
    public status: number;
    public numberOfInterns: number;
    public maximumInternsToEnroll: number;
    public durationInMonths: number;
    public scheduledToStartOn: Date;
    public scheduledToEndOn: Date;

    constructor(internship: InternshipDetailResponse) 
    {
        this.id = internship.id;
        this.status = internship.status;
        this.numberOfInterns = internship.numberOfInterns;
        this.maximumInternsToEnroll = internship.maximumInternsToEnroll;
        this.durationInMonths = internship.durationInMonths;
        this.scheduledToStartOn = internship.scheduledToStartOn;
        this.scheduledToEndOn = internship.scheduledToEndOn;
    }
}
