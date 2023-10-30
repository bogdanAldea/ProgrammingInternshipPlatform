import { ConvertedFromEnum } from "src/app/shared/models/convertedFromEnum";

export interface VersionServerResponse {
    versionId: string;
    versionNumber: string;
}

export interface TopicServerResponse {
    topicId: string;
    title: string;
    description: string;
}

export interface TopicWithVersionsServerResponse extends TopicServerResponse {
    numberOfLessons: number;
    versions: number;
    versioningState: ConvertedFromEnum;
    currentVersion?: VersionServerResponse
}

export interface NewTopicRequest {
    title: string;
    description: string;
}