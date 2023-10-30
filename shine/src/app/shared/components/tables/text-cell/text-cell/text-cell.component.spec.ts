import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TextCell } from './text-cell.component';

describe('TextCell', () => {
  let component: TextCell;
  let fixture: ComponentFixture<TextCell>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TextCell]
    });
    fixture = TestBed.createComponent(TextCell);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
