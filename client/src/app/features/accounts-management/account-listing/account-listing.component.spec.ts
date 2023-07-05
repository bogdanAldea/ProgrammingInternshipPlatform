import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AccountListingComponent } from './account-listing.component';

describe('AccountListingComponent', () => {
  let component: AccountListingComponent;
  let fixture: ComponentFixture<AccountListingComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AccountListingComponent]
    });
    fixture = TestBed.createComponent(AccountListingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
