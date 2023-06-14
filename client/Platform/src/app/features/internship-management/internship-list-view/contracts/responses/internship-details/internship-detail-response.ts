export interface InternshipDetailResponse 
{
    id: string;
    status: number;
    numberOfInterns: number;
    maximumInternsToEnroll: number;
    durationInMonths: number;
    scheduledToStartOn: Date;
    scheduledToEndOn: Date;
}
