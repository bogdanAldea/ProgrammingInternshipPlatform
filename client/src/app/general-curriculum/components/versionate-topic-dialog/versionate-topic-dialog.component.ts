import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { GeneralCurriculumService } from '../../data-access/general-curriculum.service';
import { AddEditTopicDialog, AddEditTopicData } from '../add-edit-topic-dialog/add-edit-topic-dialog.component';
import { Observable } from 'rxjs';
import { TopicWithVersions } from '../../models/topicWithVersions';
import { LessonToVersionServerResponse, TopicReadyToVersionServerResponse } from '../../models/topicReadyToVersion';
import { ModalResult } from 'src/app/shared/helpers/modals/modalResult/modalResult';

@Component({
  selector: 'versionate-topic-dialog',
  templateUrl: './versionate-topic-dialog.component.html',
  styleUrls: ['./versionate-topic-dialog.component.scss']
})
export class VersionateTopicDialog implements OnInit {
  public topic$: Observable<TopicReadyToVersionServerResponse> | undefined;
  public isLoading = true;
  public selectedLessons: LessonToVersionServerResponse[] = [];
  public allLessonsSelected = true;
  
  public constructor(
    private readonly generalCurriculumService: GeneralCurriculumService,
    public dialogRef: MatDialogRef<AddEditTopicDialog>,
    @Inject(MAT_DIALOG_DATA) private readonly data: VersionateTopicDialogData
  ) { }
  
  public ngOnInit(): void {
    this.topic$ = this.generalCurriculumService.viewTopciReadyToVersion(this.data.topicId);
    this.topic$.subscribe(() => this.isLoading = false);
    this.topic$?.forEach(topic => this.selectedLessons.push(...topic.lessons))
  }

  public selectAllLessons = (selected: boolean = true) => {
    this.selectedLessons.forEach(lesson => lesson.isSelected = selected);
  }

  public requestCloseWithOk = (): void => {
    const selectedLessons: string[] | undefined = this.allLessonsSelected 
    ? this.selectedLessons.map(lesson => lesson.lessonId) 
    : undefined;

    const request: TopicToVersionateRequest = {
      topicId: this.data.topicId,
      selectedLessons: selectedLessons,
    }

    this.dialogRef.close(ModalResult.createOkAction(request));
  };

  public requestCloseWithCancel = (): void =>
    this.dialogRef.close(ModalResult.createCancelAction());
}

export interface VersionateTopicDialogData {
  topicId: string;
}

export interface TopicToVersionateRequest {
  topicId: string;
  selectedLessons?: ReadonlyArray<string>;
}