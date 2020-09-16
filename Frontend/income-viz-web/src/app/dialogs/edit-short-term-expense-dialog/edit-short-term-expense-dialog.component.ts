import { formatDate } from '@angular/common';
import { Component, Inject } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ShortTermExpense } from '@interfaces/short-term-expense.interface';
import { GetCurrenciesAsStrings } from '@utilities/currencies';
import { MyErrorStateMatcher } from '@utilities/error-state-matcher';

@Component({
  selector: 'app-edit-short-term-expense-dialog',
  templateUrl: './edit-short-term-expense-dialog.component.html',
  styleUrls: ['./edit-short-term-expense-dialog.component.scss']
})
export class EditShortTermExpenseDialogComponent {
  currencies = GetCurrenciesAsStrings();
  stateMatcher = new MyErrorStateMatcher();

  editShortTermExpenseFormGroup = new FormGroup({
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
    executionDateFormControl: new FormControl(formatDate(this.data.executionDate, 'yyyy-MM-dd', 'en'), [
      Validators.required
    ])
  });

  constructor(
    private dialogRef: MatDialogRef<EditShortTermExpenseDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: ShortTermExpense
  ) { }

  onCancelClick(): void {
    this.dialogRef.close();
  }

  onSubmit(): void {
    const shortTermExpense: ShortTermExpense = {
      shortTermExpenseId: this.data.shortTermExpenseId,
      name: this.editShortTermExpenseFormGroup.controls.nameFormControl.value,
      amount: this.editShortTermExpenseFormGroup.controls.amountFormControl.value,
      currency: this.editShortTermExpenseFormGroup.controls.currencyFormControl.value,
      executionDate: this.editShortTermExpenseFormGroup.controls.executionDateFormControl.value
    };

    this.dialogRef.close(shortTermExpense);
  }
}
