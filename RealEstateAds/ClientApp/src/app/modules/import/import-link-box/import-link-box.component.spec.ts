import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ImportLinkBoxComponent } from './import-link-box.component';

describe('ImportLinkBoxComponent', () => {
  let component: ImportLinkBoxComponent;
  let fixture: ComponentFixture<ImportLinkBoxComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ImportLinkBoxComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ImportLinkBoxComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
