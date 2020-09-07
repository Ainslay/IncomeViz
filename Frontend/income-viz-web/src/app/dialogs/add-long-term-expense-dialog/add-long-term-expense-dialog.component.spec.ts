import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddLongTermExpenseDialogComponent } from './add-long-term-expense-dialog.component';

describe('AddLongTermExpenseDialogComponent', () => {
  let component: AddLongTermExpenseDialogComponent;
  let fixture: ComponentFixture<AddLongTermExpenseDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddLongTermExpenseDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddLongTermExpenseDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
