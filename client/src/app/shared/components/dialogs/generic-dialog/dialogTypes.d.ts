import { Type } from "@angular/core";

export interface DialogOptions<TResult> {
    header: DialogHeader;
    body?:Type< ResultProvider<TResult>>;
    actions: DialogAction[]
  }
  
  export interface DialogHeader {
    title: string;
    description?: string;
  }
  
  export interface DialogAction {
    actionName: string;
    executable: () => any;
  }
  
  export interface ResultProvider<TResult> {
    getResult(): TResult;
  }