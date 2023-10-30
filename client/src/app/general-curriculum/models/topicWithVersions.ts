import { ConvertedFromEnum } from "src/app/shared/models/convertedFromEnum";
import { TopicWithVersionsServerResponse, VersionServerResponse } from "../data-access/types";
import { VersioningState } from "./versioningState";

interface TopicVersioningState {
    name: string;
    cssClass: string;
    isReadyForVersioning: boolean;
}

export class TopicWithVersions {
    public topicId: string;
    public title: string;
    public description: string;
    public numberOfLessons: number;
    public versions: number;
    public versioningState: TopicVersioningState;
    public currentVersion?: VersionServerResponse;

    public constructor(response: TopicWithVersionsServerResponse) {
        this.topicId = response.topicId;
        this.title = response.title;
        this.description = response.description;
        this.numberOfLessons = response.numberOfLessons;
        this.versions = response.versions;
        this.versioningState = this.mapVersioningState(response.versioningState);
        this.currentVersion = response.currentVersion;
    }

    private mapVersioningState = (versioningState: ConvertedFromEnum): TopicVersioningState => {
        return {
            name: versioningState.name,
            cssClass: this.setVersioningStateClass(versioningState.value),
            isReadyForVersioning: this.isReadyForVersioning(versioningState.value)
        }
    }

    private setVersioningStateClass = (state: number): string => {
        switch (state) {
            case VersioningState.notReadyForVersioning:
                return 'not-ready-for-versioning';
            case VersioningState.readyForVersioning:
                return 'ready-for-versioning';
            default:
                throw new Error('Unsupported versioning state.');
        }
    }

    private isReadyForVersioning = (state: number): boolean => 
        state === VersioningState.readyForVersioning ? false : true;
}