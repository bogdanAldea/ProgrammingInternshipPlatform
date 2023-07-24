import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddInternshipDialogComponent } from './add-internship-dialog.component';

describe('AddInternshipDialogComponent', () => {
  let component: AddInternshipDialogComponent;
  let fixture: ComponentFixture<AddInternshipDialogComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddInternshipDialogComponent]
    });
    fixture = TestBed.createComponent(AddInternshipDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
