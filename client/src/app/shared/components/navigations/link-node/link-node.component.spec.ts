import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LinkNodeComponent } from './link-node.component';

describe('LinkNodeComponent', () => {
  let component: LinkNodeComponent;
  let fixture: ComponentFixture<LinkNodeComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [LinkNodeComponent]
    });
    fixture = TestBed.createComponent(LinkNodeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
