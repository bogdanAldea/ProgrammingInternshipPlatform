import {InternshipDetailResponse} from "../../contracts/responses/internship-details/internship-detail-response";
import { Timeframe } from "../timframe/timeframe";

export class InternshipDetails 
{
    public id: string;
    public status: number;
    public maximumInternsToEnroll: number;
    public durationInMonths: number;
    public scheduledToStartOn: Date;
    public scheduledToEndOn: Date;

    constructor(internship: InternshipDetailResponse) 
    {
        this.id = internship.id;
        this.status = internship.status;
        this.maximumInternsToEnroll = internship.maximumInternsToEnroll;
        this.durationInMonths = internship.durationInMonths;
        this.scheduledToStartOn = internship.timeframe.scheduledToStartOn;
        this.scheduledToEndOn = internship.timeframe.scheduledToEndOn;
    }
}
