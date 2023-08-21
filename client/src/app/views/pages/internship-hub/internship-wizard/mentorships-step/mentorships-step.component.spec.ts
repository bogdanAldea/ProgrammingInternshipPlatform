import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MentorshipsStepComponent } from './mentorships-step.component';

describe('MentorshipsStepComponent', () => {
  let component: MentorshipsStepComponent;
  let fixture: ComponentFixture<MentorshipsStepComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MentorshipsStepComponent]
    });
    fixture = TestBed.createComponent(MentorshipsStepComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
