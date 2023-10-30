import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MentorshipDetailComponent } from './mentorship-detail.component';

describe('MentorshipDetailComponent', () => {
  let component: MentorshipDetailComponent;
  let fixture: ComponentFixture<MentorshipDetailComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MentorshipDetailComponent]
    });
    fixture = TestBed.createComponent(MentorshipDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
