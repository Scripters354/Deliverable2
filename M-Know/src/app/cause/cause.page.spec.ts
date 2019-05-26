import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CausePage } from './cause.page';

describe('CausePage', () => {
  let component: CausePage;
  let fixture: ComponentFixture<CausePage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CausePage ],
      schemas: [CUSTOM_ELEMENTS_SCHEMA],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CausePage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
