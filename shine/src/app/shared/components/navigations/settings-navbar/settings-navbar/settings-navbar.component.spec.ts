import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SettingsNavbar } from './settings-navbar.component';

describe('SettingsNavbar', () => {
  let component: SettingsNavbar;
  let fixture: ComponentFixture<SettingsNavbar>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SettingsNavbar]
    });
    fixture = TestBed.createComponent(SettingsNavbar);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
