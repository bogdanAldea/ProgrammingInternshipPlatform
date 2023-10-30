import { Component, ElementRef, HostListener, Input, OnInit } from '@angular/core';

@Component({
  selector: 'dropdown-selector',
  templateUrl: './dropdown-selector.component.html',
  styleUrls: ['./dropdown-selector.component.scss']
})
export class DropdownSelector implements OnInit {
  public isOpen: boolean = false;
  @Input() label!: string;
  @Input() selectedValue: string | undefined;
  @Input() options: any | undefined;
  @Input() displayProperty: any;
  @Input() preselectedValue: any | undefined;


  public constructor(private elementRef: ElementRef) {}
  
  public ngOnInit(): void {
    if (this.canSetSelectedValue(this.preselectedValue, this.selectedValue)) {
      this.prepopulateSelectedValue(this.preselectedValue)
    }
  }

  public toggleDropdown() {
    this.isOpen = !this.isOpen;
  }

  public getSelectedDisplayValue(selected: any): string | undefined {
    if (selected && this.displayProperty) {
      return selected[this.displayProperty];
    }
    return undefined;
  }

  public selectOption(option: string): void {
    this.selectedValue = option;
    this.isOpen = false;
  }

  @HostListener('document:click', ['$event.target'])
  public onClick = (target: any):void => {
    const optionWasSelected = this.elementRef.nativeElement.contains(target);
    if (!optionWasSelected) {
      this.isOpen = false;
    }
  }

  private canSetSelectedValue = (preselected: any | undefined, selected: string | undefined): boolean => 
    preselected !== undefined && selected === undefined;
    
  private prepopulateSelectedValue = (value: any): void => this.selectedValue = value;
}
