import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InternshipListPage } from './internship-list.page.component';

describe('InternshipListPage', () => {
  let component: InternshipListPage;
  let fixture: ComponentFixture<InternshipListPage>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [InternshipListPage]
    });
    fixture = TestBed.createComponent(InternshipListPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
