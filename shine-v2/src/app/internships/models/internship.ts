export interface InternshipServerResponse {
    internshipId: string;
    coordinatorId: string;
    coordinatorName: string;
    coordinatorEmail: string;
    durationInMonths: number;
    maxEnrolledInterns: number;
    scheduledToStartDate: Date;
    estimatedGraduationDate: Date;
    internshipStatus: IntershipsStatusServerRespose;
}

export interface IntershipsStatusServerRespose {
    name: string;
    value: number;
}

export interface InternshipStatusColoured extends IntershipsStatusServerRespose {
    cssClass: string;
}

export class Internship {
    public internshipId: string;
    public coordinatorId: string;
    public coordinatorName: string;
    public coordinatorEmail: string;
    public durationInMonths: number;
    public maxEnrolledInterns: number;
    public scheduledToStartDate: Date;
    public estimatedGraduationDate: Date;
    public internshipStatus: IntershipsStatusServerRespose;

    public constructor(response: InternshipServerResponse) {
        this.internshipId = response.internshipId;
        this.coordinatorId = response.coordinatorId;
        this.coordinatorName = response.coordinatorName;
        this.coordinatorEmail = response.coordinatorEmail;
        this.durationInMonths = response.durationInMonths;
        this.maxEnrolledInterns = response.maxEnrolledInterns;
        this.scheduledToStartDate = response.scheduledToStartDate;
        this.estimatedGraduationDate = response.estimatedGraduationDate;
        this.internshipStatus = this.setInternshipStatusClass(response.internshipStatus);
    }

    private setInternshipStatusClass = (status: IntershipsStatusServerRespose): InternshipStatusColoured => {
        return {
            name: status.name,
            value: status.value,
            cssClass: ''
        }
    }
}