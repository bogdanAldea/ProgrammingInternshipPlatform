import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { GeneralCurriculumService } from '../../data-access/general-curriculum.service';
import { AddEditTopicDialog, AddEditTopicData } from '../add-edit-topic-dialog/add-edit-topic-dialog.component';
import { Observable } from 'rxjs';
import { TopicWithVersions } from '../../models/topicWithVersions';
import { LessonToVersionServerResponse, TopicReadyToVersionServerResponse } from '../../models/topicReadyToVersion';
import { ModalResult } from 'src/app/shared/helpers/modals/modalResult/modalResult';
import { LessonSelection } from './lessonSelection';

@Component({
  selector: 'versionate-topic-dialog',
  templateUrl: './versionate-topic-dialog.component.html',
  styleUrls: ['./versionate-topic-dialog.component.scss'],
})
export class VersionateTopicDialog implements OnInit {
  public topic$: Observable<TopicReadyToVersionServerResponse> | undefined;
  public lessonSelectionManager: LessonSelection = new LessonSelection();  
  public isLoading = true;


  public constructor(private readonly generalCurriculumService: GeneralCurriculumService,
    public dialogRef: MatDialogRef<AddEditTopicDialog>, 
    @Inject(MAT_DIALOG_DATA) private readonly data: VersionateTopicDialogData) {}

  public ngOnInit(): void {
    this.topic$ = this.generalCurriculumService.viewTopciReadyToVersion(this.data.topicId);
    this.topic$.subscribe(() => (this.isLoading = false));
    this.topic$?.forEach((topic) =>{
      this.lessonSelectionManager.registerLessons(topic.lessons as LessonToVersionServerResponse[]);
    });
  }

  public areAllLessonSelected = (isLessonSelected: boolean = true) => {
    this.lessonSelectionManager.areAllLessonSelected(isLessonSelected);
  };

  public setLessonSelectionStatus = (lessonIsSelected: boolean, lessonId: string) => {
    this.lessonSelectionManager
      .setLessonSelectionStatus(lessonIsSelected, lessonId)
      .setAllSelectedStatusAfterLessonSelection();
  }

  public requestCloseWithCancel = (): void =>
    this.dialogRef.close(ModalResult.createCancelAction());

  public requestCloseWithOk = (): void => {
    const selectedLessons = this.getSelectedLessonsForRequest();
    const request: TopicToVersionateRequest = this.createTopicVersioningRequest(this.data.topicId, selectedLessons);
    this.dialogRef.close(ModalResult.createOkAction(request));
  };

  private getSelectedLessonsForRequest = (): ReadonlyArray<string> | undefined => {
    const excludedLessons = this.lessonSelectionManager.getAllExcludedLessons();
    return excludedLessons.length > 0 ? excludedLessons : undefined;
  }

  private createTopicVersioningRequest = (topicId: string, lessons: ReadonlyArray<string> | undefined): 
  TopicToVersionateRequest => {
      return {
        topicId: topicId,
        selectedLessons: lessons
      }
  }
}

export interface VersionateTopicDialogData {
  topicId: string;
}

export interface TopicToVersionateRequest {
  topicId: string;
  selectedLessons?: ReadonlyArray<string>;
}