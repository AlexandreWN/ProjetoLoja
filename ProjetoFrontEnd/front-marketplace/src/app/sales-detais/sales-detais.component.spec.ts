import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SalesDetaisComponent } from './sales-detais.component';

describe('SalesDetaisComponent', () => {
  let component: SalesDetaisComponent;
  let fixture: ComponentFixture<SalesDetaisComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SalesDetaisComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SalesDetaisComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
