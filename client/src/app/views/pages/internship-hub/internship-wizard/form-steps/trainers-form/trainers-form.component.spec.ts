import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TrainersFormComponent } from './trainers-form.component';

describe('TrainersFormComponent', () => {
  let component: TrainersFormComponent;
  let fixture: ComponentFixture<TrainersFormComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TrainersFormComponent]
    });
    fixture = TestBed.createComponent(TrainersFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
