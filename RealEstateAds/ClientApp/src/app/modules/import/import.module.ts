import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ImportComponent } from './import/import.component';
import { ImportLinkBoxComponent } from './import-link-box/import-link-box.component';
import { FormsModule } from '@angular/forms';
import { ImportService } from './providers/import.service';


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild([
      { path: "import", component: ImportComponent }
    ])
  ],
  declarations: [
    ImportComponent,
    ImportLinkBoxComponent
  ],
  providers: [ImportService]
})
export class ImportModule { }
