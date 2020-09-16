import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { ShortTermIncome } from '@interfaces/short-term-income.interface';
import { GetCurrenciesAsStrings } from '@utilities/currencies';
import { MyErrorStateMatcher } from '@utilities/error-state-matcher';
import { Guid } from 'guid-typescript';

@Component({
  selector: 'app-add-short-term-income-dialog',
  templateUrl: './add-short-term-income-dialog.component.html',
  styleUrls: ['./add-short-term-income-dialog.component.scss']
})
export class AddShortTermIncomeDialogComponent {
  currencies = GetCurrenciesAsStrings();
  stateMatcher = new MyErrorStateMatcher();

  addShortTermIncomeFormGroup = new FormGroup({
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
    private dialogRef: MatDialogRef<AddShortTermIncomeDialogComponent>
  ) { }

  onCancelClick(): void {
    this.dialogRef.close();
  }

  onSubmit(): void {
    const shortTermIncome: ShortTermIncome = {
      shortTermIncomeId: Guid.createEmpty(),
      name: this.addShortTermIncomeFormGroup.controls.nameFormControl.value,
      amount: this.addShortTermIncomeFormGroup.controls.amountFormControl.value,
      currency: this.addShortTermIncomeFormGroup.controls.currencyFormControl.value,
      executionDate: this.addShortTermIncomeFormGroup.controls.executionDateFormControl.value
    };

    this.dialogRef.close(shortTermIncome);
  }
}
