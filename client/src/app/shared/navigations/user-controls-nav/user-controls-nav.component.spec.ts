import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserControlsNavComponent } from './user-controls-nav.component';

describe('UserControlsNavComponent', () => {
  let component: UserControlsNavComponent;
  let fixture: ComponentFixture<UserControlsNavComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UserControlsNavComponent]
    });
    fixture = TestBed.createComponent(UserControlsNavComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
