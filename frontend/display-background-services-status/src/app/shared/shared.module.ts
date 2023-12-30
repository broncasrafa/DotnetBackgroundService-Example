import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BoxStatusIconComponent } from './components/box-status-icon/box-status-icon.component';



@NgModule({
  declarations: [
    BoxStatusIconComponent
  ],
  exports: [
    BoxStatusIconComponent
  ],
  imports: [
    CommonModule
  ]
})
export class SharedModule { }
