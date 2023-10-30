import { ConvertedFromEnum } from "src/app/shared/models/convertedFromEnum";

export interface InternshipServerResponse {
    internshipId: string;
    center: ConvertedFromEnum;
    maxInternsToEnroll: number;
    durationInMonths: number;
    scheduledToStartOn: Date;
    estimatedToEndOn: Date;
    status: ConvertedFromEnum;
}

export class PartialInternship {
    public id: string;
    public status: ConvertedFromEnum;
    public center: ConvertedFromEnum;
    public maxInternsToEnroll: number;
    public durationInMonths: number;
    public scheduledToStartOn: Date;
    public estimatedToEndOn: Date;

    private constructor(response: InternshipServerResponse){
        this.id = response.internshipId;
        this.status = response.status;
        this.center = response.center
        this.maxInternsToEnroll = response.maxInternsToEnroll;
        this.durationInMonths = response.durationInMonths;
        this.scheduledToStartOn = response.scheduledToStartOn;
        this.estimatedToEndOn = response.estimatedToEndOn;
    }

    public static createFromResponse = (response: InternshipServerResponse): PartialInternship => 
        new PartialInternship(response)

}