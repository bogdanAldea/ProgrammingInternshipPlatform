import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InitialsAvatar } from './initials-avatar.component';

describe('InitialsAvatar', () => {
  let component: InitialsAvatar;
  let fixture: ComponentFixture<InitialsAvatar>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [InitialsAvatar]
    });
    fixture = TestBed.createComponent(InitialsAvatar);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
