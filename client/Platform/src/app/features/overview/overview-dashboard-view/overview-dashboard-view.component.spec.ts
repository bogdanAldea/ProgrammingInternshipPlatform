import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OverviewDashboardViewComponent } from './overview-dashboard-view.component';

describe('OverviewDashboardViewComponent', () => {
  let component: OverviewDashboardViewComponent;
  let fixture: ComponentFixture<OverviewDashboardViewComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [OverviewDashboardViewComponent]
    });
    fixture = TestBed.createComponent(OverviewDashboardViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
