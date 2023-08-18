import { Component, ElementRef, HostListener, Input } from '@angular/core';
import { FormControl } from '@angular/forms';
import { AbstractInputComponent } from '../../abstracts/abstract-input/abstract-input.component';

@Component({
  selector: 'app-filter-dropdown',
  templateUrl: './filter-dropdown.component.html',
  styleUrls: ['./filter-dropdown.component.scss']
})
export class FilterDropdownComponent extends AbstractInputComponent {
  @Input() options: string[] | undefined;
  public isOpen: boolean = false;

  public constructor(private elementRef: ElementRef) {super()}


  toggleDropdown() {
    this.isOpen = !this.isOpen;
  }

  selectOption(option: string) {
    this.selectedValue = option;
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
