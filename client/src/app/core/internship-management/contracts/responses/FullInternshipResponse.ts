export interface FullInternshipResponse 
{
    id: string;
    status: number;
    maximumInternsToEnroll: number;
    durationInMonths: number;
    scheduledToStartOn: Date;
    scheduledToEndOn: Date;
    center: string;
}