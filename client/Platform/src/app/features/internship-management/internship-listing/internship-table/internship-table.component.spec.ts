import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InternshipTableComponent } from './internship-table.component';

describe('InternshipTableComponent', () => {
  let component: InternshipTableComponent;
  let fixture: ComponentFixture<InternshipTableComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [InternshipTableComponent]
    });
    fixture = TestBed.createComponent(InternshipTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
