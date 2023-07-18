import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NoNavLayoutComponent } from './no-nav-layout.component';

describe('NoNavLayoutComponent', () => {
  let component: NoNavLayoutComponent;
  let fixture: ComponentFixture<NoNavLayoutComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [NoNavLayoutComponent]
    });
    fixture = TestBed.createComponent(NoNavLayoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
