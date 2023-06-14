import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InternshipDetailViewComponent } from './internship-detail-view.component';

describe('InternshipDetailViewComponent', () => {
  let component: InternshipDetailViewComponent;
  let fixture: ComponentFixture<InternshipDetailViewComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [InternshipDetailViewComponent]
    });
    fixture = TestBed.createComponent(InternshipDetailViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
