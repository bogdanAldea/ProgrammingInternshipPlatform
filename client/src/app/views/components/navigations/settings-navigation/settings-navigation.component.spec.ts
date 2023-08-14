import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SettingsNavigationComponent } from './settings-navigation.component';

describe('SettingsNavigationComponent', () => {
  let component: SettingsNavigationComponent;
  let fixture: ComponentFixture<SettingsNavigationComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SettingsNavigationComponent]
    });
    fixture = TestBed.createComponent(SettingsNavigationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
