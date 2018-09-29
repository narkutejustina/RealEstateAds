import { Component, OnInit } from '@angular/core';
import { ImportByLinkBox } from '../models/import-by-link-box';
import { ImportService } from '../providers/import.service';

@Component({
  templateUrl: './import.component.html',
  styleUrls: ['./import.component.scss']
})
export class ImportComponent implements OnInit {

  linkBoxes: ImportByLinkBox[];

  constructor(private importService: ImportService) {
  }

  ngOnInit() {
    this.linkBoxes = this.importService.getImportByLinkBoxes();
  }
}
