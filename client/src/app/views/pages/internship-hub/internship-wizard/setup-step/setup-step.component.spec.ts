import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SetupStepComponent } from './setup-step.component';

describe('SetupStepComponent', () => {
  let component: SetupStepComponent;
  let fixture: ComponentFixture<SetupStepComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SetupStepComponent]
    });
    fixture = TestBed.createComponent(SetupStepComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
