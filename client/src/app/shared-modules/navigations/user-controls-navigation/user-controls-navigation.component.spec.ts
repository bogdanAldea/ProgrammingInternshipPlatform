import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserControlsNavigationComponent } from './user-controls-navigation.component';

describe('UserControlsNavigationComponent', () => {
  let component: UserControlsNavigationComponent;
  let fixture: ComponentFixture<UserControlsNavigationComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UserControlsNavigationComponent]
    });
    fixture = TestBed.createComponent(UserControlsNavigationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
