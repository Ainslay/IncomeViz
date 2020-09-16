import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { ShortTermExpense } from '@interfaces/short-term-expense.interface';
import { GetCurrenciesAsStrings } from '@utilities/currencies';
import { MyErrorStateMatcher } from '@utilities/error-state-matcher';
import { Guid } from 'guid-typescript';

@Component({
  selector: 'app-add-short-term-expense-dialog',
  templateUrl: './add-short-term-expense-dialog.component.html',
  styleUrls: ['./add-short-term-expense-dialog.component.scss']
})
export class AddShortTermExpenseDialogComponent {
  currencies = GetCurrenciesAsStrings();
  stateMatcher = new MyErrorStateMatcher();

  addShortTermExpenseFormGroup = new FormGroup({
    nameFormControl: new FormControl('', [
      Validators.required,
      Validators.maxLength(50)
    ]),
    amountFormControl: new FormControl(0, [
      Validators.required,
      Validators.max(999999999),
      Validators.min(-999999999)
    ]),
    executionDateFormControl: new FormControl('', [
      Validators.required
    ]),
    currencyFormControl: new FormControl('', [
      Validators.required
    ])
  });

  constructor(
    private dialogRef: MatDialogRef<AddShortTermExpenseDialogComponent>
  ) { }

  onCancelClick(): void {
    this.dialogRef.close();
  }

  onSubmit(): void {
    const shortTermExpense: ShortTermExpense = {
      shortTermExpenseId: Guid.createEmpty(),
      name: this.addShortTermExpenseFormGroup.controls.nameFormControl.value,
      amount: this.addShortTermExpenseFormGroup.controls.amountFormControl.value,
      currency: this.addShortTermExpenseFormGroup.controls.currencyFormControl.value,
      executionDate: this.addShortTermExpenseFormGroup.controls.executionDateFormControl.value
    };

    this.dialogRef.close(shortTermExpense);
  }
}
