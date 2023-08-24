import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MentorshipsFormComponent } from './mentorships-form.component';

describe('MentorshipsFormComponent', () => {
  let component: MentorshipsFormComponent;
  let fixture: ComponentFixture<MentorshipsFormComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MentorshipsFormComponent]
    });
    fixture = TestBed.createComponent(MentorshipsFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
