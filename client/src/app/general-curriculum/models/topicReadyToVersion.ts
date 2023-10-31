export interface TopicReadyToVersionServerResponse {
    topicId: string;
    title: string;
    lessons: ReadonlyArray<LessonToVersionServerResponse>
}

export interface LessonToVersionServerResponse {
    lessonId: string;
    title: string;
    isSelected: boolean
}