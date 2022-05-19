import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddressRegisterComponent } from './address-register.component';

describe('AddressRegisterComponent', () => {
  let component: AddressRegisterComponent;
  let fixture: ComponentFixture<AddressRegisterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddressRegisterComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddressRegisterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
