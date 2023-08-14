import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NavigationLayoutComponent } from './navigation-layout.component';

describe('NavigationLayoutComponent', () => {
  let component: NavigationLayoutComponent;
  let fixture: ComponentFixture<NavigationLayoutComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [NavigationLayoutComponent]
    });
    fixture = TestBed.createComponent(NavigationLayoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
