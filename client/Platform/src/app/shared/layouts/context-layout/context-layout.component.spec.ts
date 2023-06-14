import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContextLayoutComponent } from './context-layout.component';

describe('ContextLayoutComponent', () => {
  let component: ContextLayoutComponent;
  let fixture: ComponentFixture<ContextLayoutComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ContextLayoutComponent]
    });
    fixture = TestBed.createComponent(ContextLayoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
