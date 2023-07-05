import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InternshipOptionCardComponent } from './internship-option-card.component';

describe('InternshipOptionCardComponent', () => {
  let component: InternshipOptionCardComponent;
  let fixture: ComponentFixture<InternshipOptionCardComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [InternshipOptionCardComponent]
    });
    fixture = TestBed.createComponent(InternshipOptionCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
