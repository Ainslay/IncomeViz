import { formatDate } from '@angular/common';
import { Component, Inject } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { LongTermIncome } from '@interfaces/long-term-income.interface';
import { GetCurrenciesAsStrings } from '@utilities/currencies';
import { Guid } from 'guid-typescript';
import { MyErrorStateMatcher } from './../../../utilities/error-state-matcher';

@Component({
  selector: 'app-edit-long-term-income-dialog',
  templateUrl: './edit-long-term-income-dialog.component.html',
  styleUrls: ['./edit-long-term-income-dialog.component.scss']
})
export class EditLongTermIncomeDialogComponent {
  currencies = GetCurrenciesAsStrings();
  stateMatcher = new MyErrorStateMatcher();

  editLongTermIncomeFormGroup = new FormGroup({
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
    private dialogRef: MatDialogRef<EditLongTermIncomeDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: LongTermIncome
  ) { }

  onNoClick(): void {
    this.dialogRef.close();
  }

  onSubmit(): void {
    const longTermIncome: LongTermIncome = {
      longTermIncomeId: this.data.longTermIncomeId,
      name: this.editLongTermIncomeFormGroup.controls.nameFormControl.value,
      amount: this.editLongTermIncomeFormGroup.controls.amountFormControl.value,
      currency: this.editLongTermIncomeFormGroup.controls.currencyFormControl.value,
      executionDay: this.editLongTermIncomeFormGroup.controls.executionDayFormControl.value,
      startingDate: this.editLongTermIncomeFormGroup.controls.startingDateFormControl.value,
      effectiveDate: this.editLongTermIncomeFormGroup.controls.effectiveDateFormControl.value
    };

    this.dialogRef.close(longTermIncome);
  }
}
