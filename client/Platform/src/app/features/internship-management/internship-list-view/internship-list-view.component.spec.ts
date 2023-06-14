import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InternshipListViewComponent } from './internship-list-view.component';

describe('InternshipListViewComponent', () => {
  let component: InternshipListViewComponent;
  let fixture: ComponentFixture<InternshipListViewComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [InternshipListViewComponent]
    });
    fixture = TestBed.createComponent(InternshipListViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
