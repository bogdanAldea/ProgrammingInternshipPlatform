import { Directive, ViewContainerRef } from '@angular/core';

@Directive({
  selector: '[compose]'
})
export class ComposeDirective {

  public constructor(public viewContainerRef: ViewContainerRef) { }

}
