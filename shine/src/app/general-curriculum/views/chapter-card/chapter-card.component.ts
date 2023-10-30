import { Component, Input } from '@angular/core';
import { ChapterWithVersioning } from '../../models/chapter';

@Component({
  selector: 'chapter-card',
  templateUrl: './chapter-card.component.html',
  styleUrls: ['./chapter-card.component.scss']
})
export class ChapterCard {
  @Input() chapter: ChapterWithVersioning | undefined;
  @Input() createVersion!: {execute: Function, chapterId: string;};

  public createChapterVersion = () => {
    const { execute, chapterId} = this.createVersion;

    execute(chapterId)
  };
}
