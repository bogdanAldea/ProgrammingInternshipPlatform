import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Node } from './node/node.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    Node
  ],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [
    Node
  ]
})
export class NodeModule { }
