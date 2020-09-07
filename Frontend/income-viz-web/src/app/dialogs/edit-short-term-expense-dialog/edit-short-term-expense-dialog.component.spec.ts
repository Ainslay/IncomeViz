import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditShortTermExpenseDialogComponent } from './edit-short-term-expense-dialog.component';

describe('EditShortTermExpenseDialogComponent', () => {
  let component: EditShortTermExpenseDialogComponent;
  let fixture: ComponentFixture<EditShortTermExpenseDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditShortTermExpenseDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditShortTermExpenseDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
