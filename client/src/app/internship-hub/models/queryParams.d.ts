export interface InternshipQueryParams {
        internshipStatus?: number;
        scheduledStartDate?: Date;
        estimatedGraduationDate?: Date;
        page: number;
        resultsPerPage: number;
}