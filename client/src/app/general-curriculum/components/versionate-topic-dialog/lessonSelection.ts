import { LessonToVersionServerResponse } from '../../models/topicReadyToVersion';

export class LessonSelection {
      public lessons: LessonToVersionServerResponse[] = [];
      public allLessonsAreSelected: boolean = true;

      public registerLessons = (lessons: LessonToVersionServerResponse[]) => {
      this.lessons = lessons;
      }

      public setLessonSelectionStatus = (lessonIsSelected: boolean, lessonId: string): this => {
            const selectedLesson = this.lessons.find(lesson => lesson.lessonId == lessonId)
            if (selectedLesson){
                  selectedLesson.isSelected = lessonIsSelected;
            }
            return this;
      }

      public setAllSelectedStatusAfterLessonSelection = (): this => {
            const includedLessons = this.lessons.filter(lesson => lesson.isSelected === true).length;
                  const allLessonsIncluded = this.lessons.length;
                  const areAllLessonsIncluded = includedLessons === allLessonsIncluded;
                  areAllLessonsIncluded ? this.allLessonsAreSelected = true : this.allLessonsAreSelected = false;
                  return this;
            }

      public areAllLessonSelected = (isLessonSelected: boolean = true): this => {
            this.lessons.forEach((lesson) => (lesson.isSelected = isLessonSelected));
            this.allLessonsAreSelected = isLessonSelected;
            return this;
      };

      public getAllExcludedLessons = (): ReadonlyArray<string> => {
            return this.lessons
                  .filter(lesson => lesson.isSelected === false)
                  .map(lesson => lesson.lessonId)
      }
}