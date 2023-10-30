import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Container } from './container.component';

describe('Container', () => {
  let component: Container;
  let fixture: ComponentFixture<Container>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [Container]
    });
    fixture = TestBed.createComponent(Container);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
