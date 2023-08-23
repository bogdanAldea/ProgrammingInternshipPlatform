export interface InternshipSetupRequest {
    center: number;
    coordinatorId: string;
    maxInternsToEnroll: number;
    durationInMonths: number;
    scheduledToStartOn: Date;
    estimatedToEndOn?: Date;
}