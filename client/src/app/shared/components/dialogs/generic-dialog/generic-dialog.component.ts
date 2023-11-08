import { AfterViewInit, Component, ComponentFactoryResolver, Inject, Injector, OnInit, ViewChild } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material/dialog';
import { ModalResult } from 'src/app/shared/helpers/modals/modalResult/modalResult';
import { DialogHeader, DialogAction, ResultProvider, DialogOptions } from './dialogTypes';
import { TargetDirective } from 'src/app/shared/directives/target/target.directive';

@Component({
  selector: 'generic-dialog',
  templateUrl: './generic-dialog.component.html',
  styleUrls: ['./generic-dialog.component.scss']
})
export class GenericDialog<TResult> implements AfterViewInit {
  public readonly header: DialogHeader | undefined;
  public readonly actions: DialogAction[] = [];
  public body: ResultProvider<TResult> | undefined

  @ViewChild(TargetDirective) target!: TargetDirective;

  public constructor(@Inject(MAT_DIALOG_DATA) public options: DialogOptions<TResult>,
    private readonly dialog:  MatDialogRef<GenericDialog<TResult>>) {
    this.header = options.header;
    this.actions = options.actions;
  }

  public ngAfterViewInit(): void {
    this.body = this.loadBodyComponent();
  }

  public requestCloseWithOk = (): void => {
    if (this.body) {
      const response: TResult = this.body!.getResult();
      this.dialog.close(ModalResult.createOkAction(response));
    }
  };

  public requestCloseWithCancel = (): void =>
    this.dialog.close(ModalResult.createCancelAction());

  private loadBodyComponent = () => {
    const viewContainerRef = this.target.container;
    viewContainerRef.clear();

    if (this.options.body) {
      const component = viewContainerRef.createComponent<ResultProvider<TResult>>(this.options.body!)
      return component.instance;
    }

    throw new Error('Body was not initialized.');
  }
  
}