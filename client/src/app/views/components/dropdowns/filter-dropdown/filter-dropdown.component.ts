import { Component, ElementRef, HostListener, Input } from '@angular/core';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-filter-dropdown',
  templateUrl: './filter-dropdown.component.html',
  styleUrls: ['./filter-dropdown.component.scss']
})
export class FilterDropdownComponent {
  @Input() options: string[] | undefined;
  @Input() icon: string | undefined;
  @Input() filterLabel: string | undefined;
  public isOpen: boolean = false;
  public selectedOption: string | undefined;

  public constructor(private elementRef: ElementRef) {}

  toggleDropdown() {
    this.isOpen = !this.isOpen;
  }

  selectOption(option: string) {
    this.selectedOption = option;
    this.isOpen = false;
  }

  @HostListener('document:click', ['$event.target'])
  onClick(target: any) {
    const optionWasSelected = this.elementRef.nativeElement.contains(target);
    if (!optionWasSelected) {
      this.isOpen = false;
    }
  }
}
