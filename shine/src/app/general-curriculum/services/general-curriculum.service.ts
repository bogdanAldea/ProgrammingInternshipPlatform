import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { ChapterWithVersioning, ChapterWithVersioningServerResponse } from '../models/chapter';
import { FullChapter } from '../models/chapterWithLessons';
import { LessonServerResponse } from '../models/lesson';
import { ChapterRequest } from '../models/chapterRequest';


@Injectable({
  providedIn: 'root'
})
export class GeneralCurriculumService {
  private readonly baseUrl = 'https://localhost:44308/api/Chapters'

  constructor(private readonly httpClient: HttpClient) { }

  public getAllChapters = (): Observable<ReadonlyArray<ChapterWithVersioning>> => {
    return this.httpClient.get<ReadonlyArray<ChapterWithVersioningServerResponse>>(this.baseUrl)
      .pipe(map((response: ReadonlyArray<ChapterWithVersioningServerResponse>) => {
        return response.map((response: ChapterWithVersioningServerResponse) => ChapterWithVersioning.createFromResponse(response))
      }))
  }

  public createVersionOfChapter = (chapterId: string) => {
    const url = `${this.baseUrl}/${chapterId}/version`;
    return this.httpClient.post(url, {})
  }

  public createUnversionedChapter = (request: ChapterRequest): Observable<void> => {
    return this.httpClient.post<void>(this.baseUrl, request);
  }

  public getChapterWithLessons = (chapterId: string): Observable<FullChapter> => {
    const url = `${this.baseUrl}/${chapterId}`;
    return this.httpClient.get<FullChapter>(url);
  }

  public getLessonFromUnversionedChapter = (chapterId: string): Observable<ReadonlyArray<LessonServerResponse>> => {
    const url = `${this.baseUrl}/${chapterId}/lessons`;
    return this.httpClient.get<ReadonlyArray<LessonServerResponse>>(url);
  }
}
