import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { GeneralCurriculumService } from '../../data-access/general-curriculum.service';
import { NewTopicRequest, TopicServerResponse } from '../../data-access/types';
import {
  CurriculumItemFormGroup,
  CurriculumItemGroup,
} from '../curriculum-item-form-group/topic-form-group';
import { Observable } from 'rxjs';
import { ModalAction } from 'src/app/shared/helpers/modals/modalResult/modalAction';
import { ModalResult } from 'src/app/shared/helpers/modals/modalResult/modalResult';

@Component({
  selector: 'add-edit-topic-dialog',
  templateUrl: './add-edit-topic-dialog.component.html',
  styleUrls: ['./add-edit-topic-dialog.component.scss'],
})
export class AddEditTopicDialog implements OnInit {
  public topic: TopicServerResponse | undefined;
  public dialogData: DialogData = {
    title: 'Add new topic',
    form: new CurriculumItemFormGroup(),
  };

  public constructor(
    private readonly generalCurriculumService: GeneralCurriculumService,
    public dialogRef: MatDialogRef<AddEditTopicDialog>,
    @Inject(MAT_DIALOG_DATA) private readonly data: AddEditTopicData
  ) {}

  public ngOnInit(): void {
    if (this.data.topicId !== undefined) {
      this.getTopicToEdit(this.data.topicId).subscribe(
        (topic: TopicServerResponse) => {
          this.setTopic(topic);
          this.setDialogData(topic);
        }
      );
    }
  }

  private getTopicToEdit = (topicId: string): Observable<TopicServerResponse> =>
    this.generalCurriculumService.getGeneralTopic(topicId);

  private setTopic = (topic: TopicServerResponse) => (this.topic = topic);

  private setDialogData = (topic: TopicServerResponse) => {
    const topicFormGroup: CurriculumItemGroup = {
      title: topic.title,
      description: topic.description,
    };
    this.dialogData.title = `Edit ${topic.title}`;
    this.dialogData.form = new CurriculumItemFormGroup(topicFormGroup);
  };

  public requestCloseWithOk = (): void => {
    const requestData = this.dialogData.form.value as NewTopicRequest;
    this.dialogRef.close(ModalResult.createOkAction(requestData));
  };

  public requestCloseWithCancel = (): void =>
    this.dialogRef.close(ModalResult.createCancelAction());
}

export interface AddEditTopicData {
  topicId?: string;
  existingTopicNames: ReadonlyArray<string>;
}

interface DialogData {
  title: string;
  form: CurriculumItemFormGroup;
}
