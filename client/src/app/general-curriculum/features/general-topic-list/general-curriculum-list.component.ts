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
import { ModalAction } from 'src/app/shared/helpers/modals/modalResult/modalAction';
import { NewTopicRequest } from '../../data-access/types';
import { TopicToVersionateRequest, VersionateTopicDialog, VersionateTopicDialogData } from '../../components/versionate-topic-dialog/versionate-topic-dialog.component';

@Component({
  selector: 'general-curriculum-list',
  templateUrl: './general-curriculum-list.component.html',
  styleUrls: ['./general-curriculum-list.component.scss'],
})
export class GeneralCurriculumListPage implements OnInit {
  public title = 'Topics';
  public description = 'Manage all general topics.';
  public topicActions: TopicCardActions | undefined;
  public topics: Observable<ReadonlyArray<TopicWithVersions>> | undefined;
  public existingTopicNames: string[] = [];
  public isLoading: boolean = true;

  public constructor(private readonly generalCurriculumService: GeneralCurriculumService,
    private readonly dialog: MatDialog
  ) {
    this.topicActions = {
      versionateTopic: this.versionateTopic,
      editTopic: this.editTopic,
      deleteTopic: this.deleteTopic,
    };
  }

  public ngOnInit(): void {
    this.refreshPage();
  }

  private refreshPage = () => {
    this.topics = this.getAllTopics();
    this.topics.subscribe((topics: ReadonlyArray<TopicWithVersions>) => {
      topics.forEach(topic => this.existingTopicNames.push(topic.title));
      this.isLoading = false;
    })   
  };

  private getAllTopics = (): Observable<ReadonlyArray<TopicWithVersions>> => {
      return this.generalCurriculumService.getAllGeneralTopics();
  }

  public versionateTopic = (topicId: string): void => {
    const dialogData: VersionateTopicDialogData = {
      topicId: topicId
    }

    this.dialog
      .open(VersionateTopicDialog, {data: dialogData})
      .afterClosed()
      .subscribe((response: ModalResult<TopicToVersionateRequest>) => {
        if (response.result === ModalAction.Ok && response.payload) {
          console.log(response.payload)
        }
      })
  };

  public createTopic = (): void => {
    const data: AddEditTopicData = {
      topicId: undefined,
      existingTopicNames: this.existingTopicNames,
    };

    this.dialog
      .open(AddEditTopicDialog, { data: data })
      .afterClosed()
      .subscribe((response: ModalResult<NewTopicRequest>) => {
        if (response.result === ModalAction.Ok && response.payload) {
          const observable = this.generalCurriculumService.addNewTopic(response.payload);
          observable.subscribe(() => this.isLoading = false)
          this.refreshPage();
        }  
    })
  };

  public editTopic = (topicId: string): void => {
    const data: AddEditTopicData = {
      topicId: topicId,
      existingTopicNames: this.existingTopicNames,
    };

    this.dialog
      .open(AddEditTopicDialog, { data: data })
      .afterClosed()
      .subscribe((result: ModalResult<NewTopicRequest>) => {
        if (result.result === ModalAction.Ok)
          console.log(result.payload)
    });
  };

  public deleteTopic = (topicId: string): Observable<any> => {
    return new Observable();
  };
}
