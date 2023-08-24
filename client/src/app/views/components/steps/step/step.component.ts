import { AfterContentInit, AfterViewInit, Component, Input, OnInit, ViewChild, ViewContainerRef } from '@angular/core';
import { ComposeDirective } from 'src/app/views/directives/compose.directive';
import { AbstractForm } from '../../abstracts/AbstractForm';

type NewType = ComposeDirective;

@Component({
  selector: 'app-step',
  templateUrl: './step.component.html',
  styleUrls: ['./step.component.scss']
})
export class StepComponent implements OnInit, AfterViewInit{
  @Input() public stepTitle: string | undefined;
  @Input() public form: any | undefined | AbstractForm;
  @ViewChild('compose', { read: ViewContainerRef }) compose!: ViewContainerRef;
  
  
  public ngOnInit(): void {
  }

  public ngAfterViewInit(): void {
    this.loadComponent()
  }

  public loadComponent = () => {
    this.form = this.compose.createComponent<any>(this.form).instance;
  }
}
