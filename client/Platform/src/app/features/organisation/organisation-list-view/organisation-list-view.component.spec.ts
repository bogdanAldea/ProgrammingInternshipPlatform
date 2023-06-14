import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrganisationListViewComponent } from './organisation-list-view.component';

describe('OrganisationListViewComponent', () => {
  let component: OrganisationListViewComponent;
  let fixture: ComponentFixture<OrganisationListViewComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [OrganisationListViewComponent]
    });
    fixture = TestBed.createComponent(OrganisationListViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
