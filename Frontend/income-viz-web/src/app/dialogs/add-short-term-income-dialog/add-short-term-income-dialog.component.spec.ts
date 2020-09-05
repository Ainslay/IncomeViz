import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddShortTermIncomeDialogComponent } from './add-short-term-income-dialog.component';

describe('AddShortTermIncomeDialogComponent', () => {
  let component: AddShortTermIncomeDialogComponent;
  let fixture: ComponentFixture<AddShortTermIncomeDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddShortTermIncomeDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddShortTermIncomeDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
