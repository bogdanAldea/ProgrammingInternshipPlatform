import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MentorshipParticipantCardComponent } from './mentorship-participant-card.component';

describe('MentorshipParticipantCardComponent', () => {
  let component: MentorshipParticipantCardComponent;
  let fixture: ComponentFixture<MentorshipParticipantCardComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MentorshipParticipantCardComponent]
    });
    fixture = TestBed.createComponent(MentorshipParticipantCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
