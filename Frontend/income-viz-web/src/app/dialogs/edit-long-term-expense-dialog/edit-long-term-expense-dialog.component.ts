import { formatDate } from '@angular/common';
import { Component, Inject } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { GetCurrenciesAsStrings } from '@utilities/currencies';
import { MyErrorStateMatcher } from '@utilities/error-state-matcher';
import { LongTermExpense } from '@interfaces/long-term-expense.interface';

@Component({
  selector: 'app-edit-long-term-expense-dialog',
  templateUrl: './edit-long-term-expense-dialog.component.html',
  styleUrls: ['./edit-long-term-expense-dialog.component.scss']
})
export class EditLongTermExpenseDialogComponent {
  currencies = GetCurrenciesAsStrings();
  stateMatcher = new MyErrorStateMatcher();

  editLongTermExpenseFormGroup = new FormGroup({
    nameFormControl: new FormControl(this.data.name, [
      Validators.required,
      Validators.maxLength(50)
    ]),
    amountFormControl: new FormControl(this.data.amount, [
      Validators.required,
      Validators.max(999999999),
      Validators.min(-999999999)
    ]),
    currencyFormControl: new FormControl(this.currencies[this.data.currency], [
      Validators.required
    ]),
    executionDayFormControl: new FormControl(this.data.executionDay, [
      Validators.required,
      Validators.max(28),
      Validators.min(1)
    ]),
    startingDateFormControl: new FormControl(formatDate(this.data.startingDate, 'yyyy-MM-dd', 'en'), [
      Validators.required
    ]),
    effectiveDateFormControl: new FormControl(formatDate(this.data.effectiveDate, 'yyyy-MM-dd', 'en'), [
      Validators.required
    ])
  });

  constructor(
    private dialogRef: MatDialogRef<EditLongTermExpenseDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: LongTermExpense
  ) { }

  onNoClick(): void {
    this.dialogRef.close();
  }

  onSubmit(): void {
    const longTermExpense: LongTermExpense = {
      longTermExpenseId: this.data.longTermExpenseId,
      name: this.editLongTermExpenseFormGroup.controls.nameFormControl.value,
      amount: this.editLongTermExpenseFormGroup.controls.amountFormControl.value,
      currency: this.editLongTermExpenseFormGroup.controls.currencyFormControl.value,
      executionDay: this.editLongTermExpenseFormGroup.controls.executionDayFormControl.value,
      startingDate: this.editLongTermExpenseFormGroup.controls.startingDateFormControl.value,
      effectiveDate: this.editLongTermExpenseFormGroup.controls.effectiveDateFormControl.value
    };

    this.dialogRef.close(longTermExpense);
  }
}
