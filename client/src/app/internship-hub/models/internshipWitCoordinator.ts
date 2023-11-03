import { ConvertedFromEnum } from "src/app/shared/models/convertedFromEnum";
import { InternshipStatus } from "./enums";

export interface InternshipWithCoordinatorServerResponse {
        internshipId: string;
        coordinatorId: string;
        coordinatorName:string;
        coordinatorEmail: string;
        durationInMonths: number;
        maxEnrolledInterns: number;
        scheduledToStartDate: Date;
        estimatedGraduationDate: Date;
        internshipStatus: ConvertedFromEnum;
}

export interface StatusWithCssProperties extends ConvertedFromEnum {
        cssColour: string;
}

export class InternshipWithCoordinator {
        public internshipId: string;
        public coordinatorId: string;
        public coordinatorName:string;
        public coordinatorEmail: string;
        public durationInMonths: number;
        public maxEnrolledInterns: number;
        public scheduledToStartDate: Date;
        public estimatedGraduationDate: Date;
        public internshipStatus: StatusWithCssProperties;

        public constructor(response: InternshipWithCoordinatorServerResponse) {
                this.internshipId = response.internshipId;
                this.coordinatorId = response.coordinatorId;
                this.coordinatorEmail = response.coordinatorEmail;
                this.coordinatorName = response.coordinatorName;
                this.durationInMonths = response.durationInMonths;
                this.maxEnrolledInterns = response.maxEnrolledInterns;
                this.scheduledToStartDate = response.scheduledToStartDate;
                this.estimatedGraduationDate = response.estimatedGraduationDate;
                this.internshipStatus = this.setStatusCssProperties(response.internshipStatus)
        }

        private setStatusCssProperties = (status: ConvertedFromEnum):StatusWithCssProperties  => {
                let cssColour: string = '';
                switch (status.value) {
                        case InternshipStatus.SetupInProgress:
                                cssColour =  '';
                                break;
                        case InternshipStatus.ReadyToStart:
                                cssColour =  '';
                                break;
                        case InternshipStatus.Ongoing:
                                cssColour =  '';
                                break;
                        case InternshipStatus.Abandoned:
                                cssColour =  '';
                                break;
                        case InternshipStatus.Completed:
                                cssColour = '';
                                break;
                        case InternshipStatus.Postponed:
                                cssColour =  '';
                                break;
                }

                return {
                        name: status.name,
                        value: status.value,
                        cssColour: cssColour
                }
        }
}