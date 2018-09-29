import { Injectable } from '@angular/core';
import { ImportByLinkBox } from '../models/import-by-link-box';


@Injectable()
export class ImportService {
  private importByLinkBoxes: ImportByLinkBox[] = [
    {
      imageSrc: "../../../assets/images/logos/skelbiu-logo-white.jpg",
      placeHolder: "Enter your link here ..."
    },
    {
      imageSrc: "../../../assets/images/logos/aruodas-logo.png",
      placeHolder: "Enter your link here ..."
    }
  ];

  getImportByLinkBoxes() {
    return this.importByLinkBoxes;
  }
}

