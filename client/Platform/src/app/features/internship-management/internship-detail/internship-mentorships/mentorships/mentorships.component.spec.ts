import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MentorshipsComponent } from './mentorships.component';

describe('MentorshipsComponent', () => {
  let component: MentorshipsComponent;
  let fixture: ComponentFixture<MentorshipsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MentorshipsComponent]
    });
    fixture = TestBed.createComponent(MentorshipsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
