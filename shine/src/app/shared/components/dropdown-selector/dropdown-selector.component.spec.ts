import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DropdownSelector } from './dropdown-selector.component';

describe('DropdownSelector', () => {
  let component: DropdownSelector;
  let fixture: ComponentFixture<DropdownSelector>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DropdownSelector]
    });
    fixture = TestBed.createComponent(DropdownSelector);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
