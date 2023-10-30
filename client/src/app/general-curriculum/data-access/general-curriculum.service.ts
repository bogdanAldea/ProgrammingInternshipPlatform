import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { TopicWithVersions } from '../models/topicWithVersions';
import { TopicServerResponse, TopicWithVersionsServerResponse } from './types';

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

  public addNewTopic = (topic: any): Observable<any> => {
    return new Observable();
  }
}
