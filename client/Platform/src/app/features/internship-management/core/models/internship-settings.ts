import { InternshipSettingsResponse } from "../interfaces/internship-settings";

export class InternshipSettings {
    public id: string;
    public status: string;
    public maximumInternsToEnroll: number;
    public durationInMonths: number;
    public scheduledToStartOn: Date;
    public scheduledToEndOn: Date;
    public center: string;

    constructor(response: InternshipSettingsResponse)
    {
        this.id = response.id;
        this.durationInMonths = response.durationInMonths;
        this.maximumInternsToEnroll = response.maximumInternsToEnroll;
        this.status = "";
        this.scheduledToStartOn = response.scheduledToStartOn;
        this.scheduledToEndOn = response.scheduledToEndOn;
        this.center = response.center;
    }
}