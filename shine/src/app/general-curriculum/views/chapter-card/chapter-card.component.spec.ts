import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChapterCard } from './chapter-card.component';

describe('ChapterCard', () => {
  let component: ChapterCard;
  let fixture: ComponentFixture<ChapterCard>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ChapterCard]
    });
    fixture = TestBed.createComponent(ChapterCard);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
