import { Component, Input } from '@angular/core';
import { TopicWithVersions } from '../../models/topicWithVersions';
import { Observable } from 'rxjs';

@Component({
  selector: 'topic-card',
  templateUrl: './topic-card.component.html',
  styleUrls: ['./topic-card.component.scss']
})
export class TopicCard {
  @Input() topic: TopicWithVersions | undefined;
  @Input() actions: TopicCardActions | undefined;
}

export interface TopicCardActions {
  versionateTopic(topicId: string): void;
  editTopic(topicId: string): void;
  deleteTopic(topicId: string): void;
}
