import { ConvertedFromEnum } from "src/app/shared/models/convertedFromEnum";
import { PartialVersionServerResponse } from "./partialVersionedModule";

export interface ChapterWithVersioningServerResponse {
    chapterId: string;
    title: string;
    description: string;
    numberOfLessons: number;
    versions: number;
    versioningState: ConvertedFromEnum;
    currentVersion?: PartialVersionServerResponse
}


export class ChapterWithVersioning {
    public chapterId: string;
    public title: string;
    public description: string;
    public numberOfLessons: number;
    public versions: number;
    public versioningState: ConvertedFromEnum;
    public currentVersion?: PartialVersionServerResponse;

    public constructor(chapterResponse: ChapterWithVersioningServerResponse) {
        this.chapterId = chapterResponse.chapterId;
        this.title = chapterResponse.title;
        this.description = chapterResponse.description;
        this.numberOfLessons = chapterResponse.numberOfLessons;
        this.versions = chapterResponse.versions;
        this.versioningState = chapterResponse.versioningState;
        this.currentVersion = chapterResponse.currentVersion;
    }

    public static createFromResponse = (response: ChapterWithVersioningServerResponse): ChapterWithVersioning =>
        new ChapterWithVersioning(response)
}