import { Component, OnInit } from '@angular/core';
import { GeneralCurriculumService } from '../../data-access/general-curriculum.service';
import { TopicWithVersions } from '../../models/topicWithVersions';
import { Observable } from 'rxjs';
import { TopicCardActions } from '../../components/topic-card/topic-card.component';
import {
  MatDialog,
  MatDialogRef,
  MatDialogModule,
} from '@angular/material/dialog';
import {
  AddEditTopicData,
  AddEditTopicDialog,
} from '../../components/add-edit-topic-dialog/add-edit-topic-dialog.component';
import { ModalResult } from 'src/app/shared/helpers/modals/modalResult/modalResult';
import { ActionResult } from 'src/app/shared/helpers/modals/modalResult/modalActionResult';
import { ModalAction } from 'src/app/shared/helpers/modals/modalResult/modalAction';
import { NewTopicRequest } from '../../data-access/types';

@Component({
  selector: 'general-curriculum-list',
  templateUrl: './general-curriculum-list.component.html',
  styleUrls: ['./general-curriculum-list.component.scss'],
})
export class GeneralCurriculumListPage implements OnInit {
  public title = 'Topics';
  public description = 'Manage all general topics.';
  public generalTopics: ReadonlyArray<TopicWithVersions> | undefined;
  public topicActions: TopicCardActions | undefined;

  public constructor(
    private readonly generalCurriculumService: GeneralCurriculumService,
    private readonly dialog: MatDialog
  ) {
    this.topicActions = {
      versionateTopic: this.versionateTopic,
      editTopic: this.editTopic,
      deleteTopic: this.deleteTopic,
    };
  }

  public ngOnInit(): void {
    this.generalCurriculumService
      .getAllGeneralTopics()
      .subscribe((response) => {
        this.generalTopics = response;
      });
  }

  private refreshPage = () => {
    this.generalCurriculumService
      .getAllGeneralTopics()
      .subscribe((response) => {
        this.generalTopics = response;
      });
  };

  public versionateTopic = (topicId: string): Observable<any> => {
    return new Observable();
  };

  public createTopic = (): Observable<any> => {
    const data: AddEditTopicData = {
      topicId: undefined,
      existingTopicNames: this.generalTopics!.map((topic) => topic.title),
    };

    this.dialog.open(AddEditTopicDialog, { data: data });
    return new Observable();
  };

  public editTopic = (topicId: string): void => {
    const data: AddEditTopicData = {
      topicId: topicId,
      existingTopicNames: this.generalTopics!.map((topic) => topic.title),
    };

    const dialog = this.dialog.open(AddEditTopicDialog, { data: data });

    dialog.afterClosed().subscribe((result: ModalResult<NewTopicRequest>) => {
      if (result.result === ModalAction.Ok)
        console.log(result.payload)
    });
  };

  public deleteTopic = (topicId: string): Observable<any> => {
    return new Observable();
  };
}
