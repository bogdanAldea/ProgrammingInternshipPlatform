import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LayoutWithoutNavigationComponent } from './layout-without-navigation.component';

describe('LayoutWithoutNavigationComponent', () => {
  let component: LayoutWithoutNavigationComponent;
  let fixture: ComponentFixture<LayoutWithoutNavigationComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [LayoutWithoutNavigationComponent]
    });
    fixture = TestBed.createComponent(LayoutWithoutNavigationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
