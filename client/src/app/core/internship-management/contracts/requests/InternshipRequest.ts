export interface InternshipRequest 
{
    companyId: string;
    locationId: string;
    maximumInternsToEnroll: number;
    durationInMonths: number;
    scheduledToStartOnDate: Date;
}