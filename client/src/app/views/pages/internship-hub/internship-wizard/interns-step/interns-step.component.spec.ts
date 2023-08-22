import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InternsStepComponent } from './interns-step.component';

describe('InternsStepComponent', () => {
  let component: InternsStepComponent;
  let fixture: ComponentFixture<InternsStepComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [InternsStepComponent]
    });
    fixture = TestBed.createComponent(InternsStepComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
