import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InlineNavigationComponent } from './inline-navigation.component';

describe('InlineNavigationComponent', () => {
  let component: InlineNavigationComponent;
  let fixture: ComponentFixture<InlineNavigationComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [InlineNavigationComponent]
    });
    fixture = TestBed.createComponent(InlineNavigationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
