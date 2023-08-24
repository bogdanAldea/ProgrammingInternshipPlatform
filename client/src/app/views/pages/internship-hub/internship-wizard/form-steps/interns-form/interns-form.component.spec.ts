import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InternsFormComponent } from './interns-form.component';

describe('InternsFormComponent', () => {
  let component: InternsFormComponent;
  let fixture: ComponentFixture<InternsFormComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [InternsFormComponent]
    });
    fixture = TestBed.createComponent(InternsFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
