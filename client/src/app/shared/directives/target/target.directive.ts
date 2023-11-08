import { Directive, ViewContainerRef } from '@angular/core';

@Directive({
  selector: '[target]'
})
export class TargetDirective {

  public constructor(public container: ViewContainerRef) { }

}
