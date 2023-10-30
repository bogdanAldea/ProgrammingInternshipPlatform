import { ConvertedFromEnum } from "src/app/shared/models/convertedFromEnum";
import { LessonServerResponse } from "./lesson";
import { PartialVersionServerResponse } from "./partialVersionedModule";
import { ChapterWithVersioningServerResponse } from "./chapter";

export interface ChapterWithLessonsServerResponse extends ChapterWithVersioningServerResponse {
    lessons: number;
    chapterType: ConvertedFromEnum;
}

export class FullChapter {
    public chapterId: string;
    public title: string;
    public description: string;
    public numberOfLessons: number;
    public versions: number;
    public chapterType: ConvertedFromEnum
    public versioningState: ConvertedFromEnum;
    public currentVersion?: PartialVersionServerResponse;

    public constructor(chapterResponse: ChapterWithLessonsServerResponse) {
        this.chapterId = chapterResponse.chapterId;
        this.title = chapterResponse.title;
        this.description = chapterResponse.description;
        this.numberOfLessons = chapterResponse.numberOfLessons;
        this.versions = chapterResponse.versions;
        this.versioningState = chapterResponse.versioningState;
        this.currentVersion = chapterResponse.currentVersion;
        this.chapterType = chapterResponse.chapterType
    }

    public static createFromResponse = (response: ChapterWithLessonsServerResponse): FullChapter =>
        new FullChapter(response)
}