import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AbstractInputComponent } from './abstract-input.component';

describe('AbstractInputComponent', () => {
  let component: AbstractInputComponent;
  let fixture: ComponentFixture<AbstractInputComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AbstractInputComponent]
    });
    fixture = TestBed.createComponent(AbstractInputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
