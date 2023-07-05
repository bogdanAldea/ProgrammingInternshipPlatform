import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ButtonRectSmallComponent } from './button-rect-small.component';

describe('ButtonRectSmallComponent', () => {
  let component: ButtonRectSmallComponent;
  let fixture: ComponentFixture<ButtonRectSmallComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ButtonRectSmallComponent]
    });
    fixture = TestBed.createComponent(ButtonRectSmallComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
