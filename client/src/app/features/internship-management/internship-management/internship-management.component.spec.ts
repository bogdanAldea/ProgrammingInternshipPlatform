import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InternshipManagementComponent } from './internship-management.component';

describe('InternshipManagementComponent', () => {
  let component: InternshipManagementComponent;
  let fixture: ComponentFixture<InternshipManagementComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [InternshipManagementComponent]
    });
    fixture = TestBed.createComponent(InternshipManagementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
