import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PreventionPage } from './prevention.page';

describe('PreventionPage', () => {
  let component: PreventionPage;
  let fixture: ComponentFixture<PreventionPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PreventionPage ],
      schemas: [CUSTOM_ELEMENTS_SCHEMA],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PreventionPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
