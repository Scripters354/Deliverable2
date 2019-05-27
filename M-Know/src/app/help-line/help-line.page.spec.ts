import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HelpLinePage } from './help-line.page';

describe('HelpLinePage', () => {
  let component: HelpLinePage;
  let fixture: ComponentFixture<HelpLinePage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HelpLinePage ],
      schemas: [CUSTOM_ELEMENTS_SCHEMA],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HelpLinePage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
