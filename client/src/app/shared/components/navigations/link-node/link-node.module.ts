import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LinkNode } from './link-node.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [LinkNode],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [LinkNode]
})
export class LinkNodeModule { }
