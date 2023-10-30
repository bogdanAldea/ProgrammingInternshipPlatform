import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MentorshipMemberCard } from './mentorship-member-card.component';

describe('MentorshipMemberCard', () => {
  let component: MentorshipMemberCard;
  let fixture: ComponentFixture<MentorshipMemberCard>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MentorshipMemberCard]
    });
    fixture = TestBed.createComponent(MentorshipMemberCard);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
