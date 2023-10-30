import { Component, Input } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { MatIconRegistry } from '@angular/material/icon';

@Component({
  selector: 'date-picker',
  templateUrl: './date-picker.component.html',
  styleUrls: ['./date-picker.component.scss'],
})
export class DatePicker {
  @Input() preselectedDate: Date | undefined;
  @Input() minDate: Date = new Date();

  public constructor(
    private matIconRegistry: MatIconRegistry,
    private domSanitizer: DomSanitizer) 
    {
      this.matIconRegistry.addSvgIcon(
        'calendar',
        this.domSanitizer.bypassSecurityTrustResourceUrl('../../../../../assets/icons/muted/Menu/Presentations.svg')
      );
    }
}
