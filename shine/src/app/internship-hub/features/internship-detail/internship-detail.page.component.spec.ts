import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InternshipDetailPage } from './internship-detail.page.component';

describe('InternshipDetailPage', () => {
  let component: InternshipDetailPage;
  let fixture: ComponentFixture<InternshipDetailPage>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [InternshipDetailPage]
    });
    fixture = TestBed.createComponent(InternshipDetailPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
