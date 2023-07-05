import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StackedNavigationComponent } from './stacked-navigation.component';

describe('StackedNavigationComponent', () => {
  let component: StackedNavigationComponent;
  let fixture: ComponentFixture<StackedNavigationComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [StackedNavigationComponent]
    });
    fixture = TestBed.createComponent(StackedNavigationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
