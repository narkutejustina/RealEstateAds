import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'import-link-box',
  templateUrl: './import-link-box.component.html',
  styleUrls: ['./import-link-box.component.css']
})
export class ImportLinkBoxComponent {

  @Input() imageSrc: string;
  @Input() placeHolder: string;

  @Output() submit: EventEmitter<string> = new EventEmitter<string>();

  linkToAd: string = "";

  onSubmit() {
    this.submit.emit(this.linkToAd);
  }
}
