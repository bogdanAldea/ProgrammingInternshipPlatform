import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LayoutWithNavigationComponent } from './layout-with-navigation.component';

describe('LayoutWithNavigationComponent', () => {
  let component: LayoutWithNavigationComponent;
  let fixture: ComponentFixture<LayoutWithNavigationComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [LayoutWithNavigationComponent]
    });
    fixture = TestBed.createComponent(LayoutWithNavigationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
