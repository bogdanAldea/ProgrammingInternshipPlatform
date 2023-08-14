import { DatePipe } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatIconRegistry } from '@angular/material/icon';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-date-picker',
  templateUrl: './date-picker.component.html',
  styleUrls: ['./date-picker.component.scss']
})
export class DatePickerComponent implements OnInit {
  @Input() public deadline: Date | undefined;
  public deadlineFormControl: FormControl = new FormControl();

  public constructor(
    private iconRegistry: MatIconRegistry,
    private sanitizer: DomSanitizer,
    ) 
    {
      this.iconRegistry.addSvgIcon('app_calendar', 
      this.sanitizer.bypassSecurityTrustResourceUrl('../../../../../assets/icons/light/Menu/Presentations.svg'))
    }
  
  public ngOnInit(): void {
    this.deadlineFormControl = new FormControl(this.deadline)
  }
}
