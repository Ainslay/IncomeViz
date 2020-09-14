import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditLongTermExpenseDialogComponent } from './edit-long-term-expense-dialog.component';

describe('EditLongTermExpenseDialogComponent', () => {
  let component: EditLongTermExpenseDialogComponent;
  let fixture: ComponentFixture<EditLongTermExpenseDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditLongTermExpenseDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditLongTermExpenseDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
