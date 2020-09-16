import { formatDate } from '@angular/common';
import { Component, Inject } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Prediction } from '@interfaces/prediction.interface';
import { GetCurrenciesAsStrings } from '@utilities/currencies';
import { MyErrorStateMatcher } from '@utilities/error-state-matcher';

@Component({
  selector: 'app-edit-prediction-dialog',
  templateUrl: './edit-prediction-dialog.component.html',
  styleUrls: ['./edit-prediction-dialog.component.scss']
})
export class EditPredictionDialogComponent {
  currencies = GetCurrenciesAsStrings();
  stateMatcher = new MyErrorStateMatcher();

  editPredictionFormGroup = new FormGroup({
    nameFormControl: new FormControl(this.data.name, [
      Validators.required,
      Validators.maxLength(50)
    ]),
    inicialCapitalFormControl: new FormControl(this.data.amount, [
      Validators.required,
      Validators.max(999999999),
      Validators.min(-999999999)
    ]),
    dateFormControl: new FormControl(formatDate(this.data.startingDate, 'yyyy-MM-dd', 'en'), [
      Validators.required
    ]),
    currencyFormControl: new FormControl(this.currencies[this.data.currency], [
      Validators.required
    ])
  });

  constructor(
    private dialogRef: MatDialogRef<EditPredictionDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Prediction
  ) { }

  onCancelClick(): void {
    this.dialogRef.close();
  }

  onSubmit(): void {
    const predicion: Prediction = {
      id: this.data.id,
      name: this.editPredictionFormGroup.controls.nameFormControl.value,
      amount: this.editPredictionFormGroup.controls.inicialCapitalFormControl.value,
      currency: this.editPredictionFormGroup.controls.currencyFormControl.value,
      startingDate: this.editPredictionFormGroup.controls.dateFormControl.value
    };

    this.dialogRef.close(predicion);
  }
}
