import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CurriculumListViewComponent } from './curriculum-list-view.component';

describe('CurriculumListViewComponent', () => {
  let component: CurriculumListViewComponent;
  let fixture: ComponentFixture<CurriculumListViewComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CurriculumListViewComponent]
    });
    fixture = TestBed.createComponent(CurriculumListViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
