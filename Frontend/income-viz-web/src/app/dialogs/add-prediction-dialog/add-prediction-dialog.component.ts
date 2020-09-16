import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { Prediction } from '@interfaces/prediction.interface';
import { GetCurrenciesAsStrings } from '@utilities/currencies';
import { MyErrorStateMatcher } from '@utilities/error-state-matcher';
import { Guid } from 'guid-typescript';

@Component({
  selector: 'app-add-prediction-dialog',
  templateUrl: './add-prediction-dialog.component.html',
  styleUrls: ['./add-prediction-dialog.component.scss']
})
export class AddPredictionDialogComponent {
  currencies = GetCurrenciesAsStrings();
  stateMatcher = new MyErrorStateMatcher();

  addPredictionFormGroup = new FormGroup({
    nameFormControl: new FormControl('', [
      Validators.required,
      Validators.maxLength(50)
    ]),
    inicialCapitalFormControl: new FormControl(0, [
      Validators.required,
      Validators.max(999999999),
      Validators.min(-999999999)
    ]),
    dateFormControl: new FormControl('', [
      Validators.required
    ]),
    currencyFormControl: new FormControl('', [
      Validators.required
    ])
  });

  constructor(
    public dialogRef: MatDialogRef<AddPredictionDialogComponent>
  ) { }

  onCancelClick(): void {
    this.dialogRef.close();
  }

  onSubmit(): void {
    const predicion: Prediction = {
      id: Guid.createEmpty(),
      name: this.addPredictionFormGroup.controls.nameFormControl.value,
      amount: this.addPredictionFormGroup.controls.inicialCapitalFormControl.value,
      currency: this.addPredictionFormGroup.controls.currencyFormControl.value,
      startingDate: this.addPredictionFormGroup.controls.dateFormControl.value
    };

    this.dialogRef.close(predicion);
  }
}

