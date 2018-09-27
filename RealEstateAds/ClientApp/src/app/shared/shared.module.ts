import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CommingSoonComponent } from './components/comming-soon/comming-soon.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [CommingSoonComponent],
  export: [CommingSoonComponent]
})
export class SharedModule { }