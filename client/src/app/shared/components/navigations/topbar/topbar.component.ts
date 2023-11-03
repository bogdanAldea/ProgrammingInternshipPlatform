import { Component, OnInit } from '@angular/core';

type NewType = OnInit;

@Component({
  selector: 'topbar',
  templateUrl: './topbar.component.html',
  styleUrls: ['./topbar.component.scss']
})
export class Topbar implements NewType {
  public todayDate: TodayDate | undefined;

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
