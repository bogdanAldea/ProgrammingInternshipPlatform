import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InternshipsTable } from './internships-table.component';

describe('InternshipsTable', () => {
  let component: InternshipsTable;
  let fixture: ComponentFixture<InternshipsTable>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [InternshipsTable]
    });
    fixture = TestBed.createComponent(InternshipsTable);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
