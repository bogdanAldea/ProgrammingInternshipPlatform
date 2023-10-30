import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Spinner } from './spinner.component';

describe('Spinner', () => {
  let component: Spinner;
  let fixture: ComponentFixture<Spinner>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [Spinner]
    });
    fixture = TestBed.createComponent(Spinner);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
