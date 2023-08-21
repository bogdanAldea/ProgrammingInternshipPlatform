import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TrainersStepComponent } from './trainers-step.component';

describe('TrainersStepComponent', () => {
  let component: TrainersStepComponent;
  let fixture: ComponentFixture<TrainersStepComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TrainersStepComponent]
    });
    fixture = TestBed.createComponent(TrainersStepComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
