import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { LongTermExpense } from '@interfaces/long-term-expense.interface';
import { GetCurrenciesAsStrings } from '@utilities/currencies';
import { MyErrorStateMatcher } from '@utilities/error-state-matcher';
import { Guid } from 'guid-typescript';

@Component({
  selector: 'app-add-long-term-expense-dialog',
  templateUrl: './add-long-term-expense-dialog.component.html',
  styleUrls: ['./add-long-term-expense-dialog.component.scss']
})
export class AddLongTermExpenseDialogComponent {
  currencies = GetCurrenciesAsStrings();
  stateMatcher = new MyErrorStateMatcher();

  addLongTermExpenseFormGroup = new FormGroup({
    nameFormControl: new FormControl('', [
      Validators.required,
      Validators.maxLength(50)
    ]),
    amountFormControl: new FormControl(0, [
      Validators.required,
      Validators.max(999999999),
      Validators.min(-999999999)
    ]),
    currencyFormControl: new FormControl('', [
      Validators.required
    ]),
    executionDayFormControl: new FormControl(10, [
      Validators.required,
      Validators.max(28),
      Validators.min(1)
    ]),
    startingDateFormControl: new FormControl(new Date(), [
      Validators.required
    ]),
    effectiveDateFormControl: new FormControl(new Date(), [
      Validators.required
    ])
  });

  constructor(
    private dialogRef: MatDialogRef<AddLongTermExpenseDialogComponent>
  ) { }

  onCancelClick(): void {
    this.dialogRef.close();
  }

  onSubmit(): void {
    const longTermExpense: LongTermExpense = {
      longTermExpenseId: Guid.createEmpty(),
      name: this.addLongTermExpenseFormGroup.controls.nameFormControl.value,
      amount: this.addLongTermExpenseFormGroup.controls.amountFormControl.value,
      currency: this.addLongTermExpenseFormGroup.controls.currencyFormControl.value,
      executionDay: this.addLongTermExpenseFormGroup.controls.executionDayFormControl.value,
      startingDate: this.addLongTermExpenseFormGroup.controls.startingDateFormControl.value,
      effectiveDate: this.addLongTermExpenseFormGroup.controls.effectiveDateFormControl.value
    };

    this.dialogRef.close(longTermExpense);
  }

  compareDates(): boolean {
    const startingDate = new Date(this.addLongTermExpenseFormGroup.controls.startingDateFormControl.value);
    const effectiveDate = new Date(this.addLongTermExpenseFormGroup.controls.effectiveDateFormControl.value);

    return (startingDate >= effectiveDate);
  }
}
