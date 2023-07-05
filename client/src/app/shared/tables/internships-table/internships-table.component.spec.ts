import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InternshipsTableComponent } from './internships-table.component';

describe('InternshipsTableComponent', () => {
  let component: InternshipsTableComponent;
  let fixture: ComponentFixture<InternshipsTableComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [InternshipsTableComponent]
    });
    fixture = TestBed.createComponent(InternshipsTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
