import { Component, EventEmitter, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { LongTermIncome } from '@interfaces/long-term-income.interface';
import { GetCurrenciesAsStrings } from '@utilities/currencies';
import { MyErrorStateMatcher } from '@utilities/error-state-matcher';
import { Guid } from 'guid-typescript';

@Component({
  selector: 'app-add-long-term-income-dialog',
  templateUrl: './add-long-term-income-dialog.component.html',
  styleUrls: ['./add-long-term-income-dialog.component.scss']
})
export class AddLongTermIncomeDialogComponent {
  @Output() addRequest: EventEmitter<LongTermIncome> = new EventEmitter<LongTermIncome>();
  currencies = GetCurrenciesAsStrings();
  stateMatcher = new MyErrorStateMatcher();

  addLongTermIncomeFormGroup = new FormGroup({
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
    private dialogRef: MatDialogRef<AddLongTermIncomeDialogComponent>
  ) { }

  onNoClick(): void {
    this.dialogRef.close();
  }

  onSubmit(): void {
    const longTermIncome: LongTermIncome = {
      longTermIncomeId: Guid.createEmpty(),
      name: this.addLongTermIncomeFormGroup.controls.nameFormControl.value,
      amount: this.addLongTermIncomeFormGroup.controls.amountFormControl.value,
      currency: this.addLongTermIncomeFormGroup.controls.currencyFormControl.value,
      executionDay: this.addLongTermIncomeFormGroup.controls.executionDayFormControl.value,
      startingDate: this.addLongTermIncomeFormGroup.controls.startingDateFormControl.value,
      effectiveDate: this.addLongTermIncomeFormGroup.controls.effectiveDateFormControl.value
    };

    this.addRequest.emit(longTermIncome);
    this.dialogRef.close();
  }

  compareDates(): boolean {
    const startingDate = new Date(this.addLongTermIncomeFormGroup.controls.startingDateFormControl.value);
    const effectiveDate = new Date(this.addLongTermIncomeFormGroup.controls.effectiveDateFormControl.value);

    return (startingDate >= effectiveDate);
  }
}
