import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PictureAvatarComponent } from './picture-avatar.component';

describe('PictureAvatarComponent', () => {
  let component: PictureAvatarComponent;
  let fixture: ComponentFixture<PictureAvatarComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PictureAvatarComponent]
    });
    fixture = TestBed.createComponent(PictureAvatarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
