import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MentorshipTaskCardComponent } from './mentorship-task-card.component';

describe('MentorshipTaskCardComponent', () => {
  let component: MentorshipTaskCardComponent;
  let fixture: ComponentFixture<MentorshipTaskCardComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MentorshipTaskCardComponent]
    });
    fixture = TestBed.createComponent(MentorshipTaskCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
