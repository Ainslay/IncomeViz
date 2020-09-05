import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddShortTermExpenseDialogComponent } from './add-short-term-expense-dialog.component';

describe('AddShortTermExpenseDialogComponent', () => {
  let component: AddShortTermExpenseDialogComponent;
  let fixture: ComponentFixture<AddShortTermExpenseDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddShortTermExpenseDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddShortTermExpenseDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
