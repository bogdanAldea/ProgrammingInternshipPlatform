import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ActionCard } from './action-card.component';

describe('ActionCard', () => {
  let component: ActionCard;
  let fixture: ComponentFixture<ActionCard>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ActionCard]
    });
    fixture = TestBed.createComponent(ActionCard);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
