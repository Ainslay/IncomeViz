import { formatDate } from '@angular/common';
import { Component, Inject } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ShortTermIncome } from '@interfaces/short-term-income.interface';
import { GetCurrenciesAsStrings } from '@utilities/currencies';
import { MyErrorStateMatcher } from '@utilities/error-state-matcher';

@Component({
  selector: 'app-edit-short-term-income-dialog',
  templateUrl: './edit-short-term-income-dialog.component.html',
  styleUrls: ['./edit-short-term-income-dialog.component.scss']
})
export class EditShortTermIncomeDialogComponent {
  currencies = GetCurrenciesAsStrings();
  stateMatcher = new MyErrorStateMatcher();

  editShortTermIncomeFormGroup = new FormGroup({
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
    private dialogRef: MatDialogRef<EditShortTermIncomeDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: ShortTermIncome
  ) { }

  onCancelClick(): void {
    this.dialogRef.close();
  }

  onSubmit(): void {
    const shortTermIncome: ShortTermIncome = {
      shortTermIncomeId: this.data.shortTermIncomeId,
      name: this.editShortTermIncomeFormGroup.controls.nameFormControl.value,
      amount: this.editShortTermIncomeFormGroup.controls.amountFormControl.value,
      currency: this.editShortTermIncomeFormGroup.controls.currencyFormControl.value,
      executionDate: this.editShortTermIncomeFormGroup.controls.executionDateFormControl.value
    };

    this.dialogRef.close(shortTermIncome);
  }
}
