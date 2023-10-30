import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { InternshipWithCoordinator, InternshipWithCoordinatorResponse } from '../../models/internshipWithCoordinator';
import { InternshipServerResponse, PartialInternship } from '../../models/partialInternship';
import { MentorshipPair, MentorshipPairServerResponse } from '../../models/mentorshipPair';

@Injectable({
  providedIn: 'root'
})
export class InternshipService {
  private readonly url: string  = 'https://localhost:44308/api/Internships'
  
  constructor(private httpClient: HttpClient) { }

  public getAllInternshipPrograms = (): Observable<InternshipWithCoordinator[]> => {
    return this.httpClient.get<InternshipWithCoordinatorResponse[]>(this.url)
      .pipe(map((response: InternshipWithCoordinatorResponse[]) => {
        return response.map((response: InternshipWithCoordinatorResponse) => 
          InternshipWithCoordinator.createFromResponse(response))
      }))
  }

  public getInternshipSetupConfiguration = (internshipId: string): Observable<PartialInternship> => {
    const url: string  = `${this.url}/${internshipId}/setup`
    return this.httpClient.get<InternshipServerResponse>(url)
      .pipe(map((response: InternshipServerResponse) => {
        return PartialInternship.createFromResponse(response);
      }))
  }

  public getAllMentorshipPairs = (internshipId: string): Observable<MentorshipPair[]> => {
    const url: string  = `${this.url}/${internshipId}/mentorships`;
    return this.httpClient.get<MentorshipPairServerResponse[]>(url)
      .pipe(map((response: MentorshipPairServerResponse[]) => {
        return response.map(pair => MentorshipPair.createFromResponse(pair));
      }));
  }

  public getMentorshipPair = (internshipId: string, mentorshipId: string): Observable<MentorshipPair> => {
    const url: string = `${this.url}/${internshipId}/mentorships/${mentorshipId}`;
    return this.httpClient.get<MentorshipPairServerResponse>(url)
      .pipe(map((response: MentorshipPairServerResponse) => {
        return MentorshipPair.createFromResponse(response);
      }))
  }
}
