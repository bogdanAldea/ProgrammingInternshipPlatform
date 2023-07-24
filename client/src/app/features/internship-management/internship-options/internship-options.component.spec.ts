import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InternshipOptionsComponent } from './internship-options.component';

describe('InternshipOptionsComponent', () => {
  let component: InternshipOptionsComponent;
  let fixture: ComponentFixture<InternshipOptionsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [InternshipOptionsComponent]
    });
    fixture = TestBed.createComponent(InternshipOptionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
