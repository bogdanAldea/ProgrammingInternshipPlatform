import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { TopicWithVersions } from '../models/topicWithVersions';
import { NewTopicRequest, TopicServerResponse, TopicWithVersionsServerResponse } from './types';
import { TopicReadyToVersionServerResponse } from '../models/topicReadyToVersion';

@Injectable({
  providedIn: 'root'
})
export class GeneralCurriculumService {
  private readonly baseUrl = 'https://localhost:44308/api/Topics'

  constructor(private readonly httpClient: HttpClient) { }

  public getGeneralTopic = (topicId: string): Observable<TopicServerResponse> => {
    const url = `${this.baseUrl}/${topicId}`;
    return this.httpClient.get<TopicServerResponse>(url);
  }

  public getAllGeneralTopics = (): Observable<ReadonlyArray<TopicWithVersions>> => {
    return this.httpClient.get<ReadonlyArray<TopicWithVersionsServerResponse>>(this.baseUrl)
      .pipe(map((response: ReadonlyArray<TopicWithVersionsServerResponse>) => {
        return response.map((response: TopicWithVersionsServerResponse) => new TopicWithVersions(response))
      }))
  }

  public viewTopciReadyToVersion = (topicId: string): Observable<TopicReadyToVersionServerResponse> => {
    const url = `${this.baseUrl}/${topicId}/ready-to-version`;
    return this.httpClient.get<TopicReadyToVersionServerResponse>(url);
  } 

  public addNewTopic = (topic: NewTopicRequest): Observable<any> => {
    console.log('in service')
    return this.httpClient.post(this.baseUrl, topic);
  }
}
