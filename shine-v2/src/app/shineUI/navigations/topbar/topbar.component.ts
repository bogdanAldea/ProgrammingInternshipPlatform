import { Component, Input } from '@angular/core';
import { Account } from 'src/app/shared/services/accounts.service';
import { Observable } from 'rxjs';

@Component({
  selector: 's-topbar',
  templateUrl: './topbar.component.html',
  styleUrls: ['./topbar.component.scss']
})
export class TopbarComponent {
  public todayDate: TodayDate | undefined;
  @Input() account$!: Observable<Account>;

  public ngOnInit(): void {
    this.todayDate = this.getTodaysDate();
  }

  private getTodaysDate = (): TodayDate => {
    const today: Date = new Date();
    return {
      day: today.toLocaleDateString('en-US', {day: 'numeric'}),
      month: today.toLocaleDateString('en-US', {month: 'short'}),
      year: today.toLocaleDateString('en-US', {year: 'numeric'}),
    }
  }
}

interface TodayDate {
  day: string;
  month: string;
  year: string;
}