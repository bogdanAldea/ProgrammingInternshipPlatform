import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DatePicker } from './date-picker.component';

describe('DatePicker', () => {
  let component: DatePicker;
  let fixture: ComponentFixture<DatePicker>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DatePicker]
    });
    fixture = TestBed.createComponent(DatePicker);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
