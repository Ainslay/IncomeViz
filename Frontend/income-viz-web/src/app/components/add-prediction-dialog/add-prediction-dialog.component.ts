import { Component, EventEmitter, Output } from '@angular/core';
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
  @Output() addRequest: EventEmitter<Prediction> = new EventEmitter<Prediction>();
  prediction: Prediction = { id: Guid.create(), name: '', startingDate: new Date(), amount: 0, currency: 'PLN'};
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

  onNoClick(): void {
    this.dialogRef.close();
  }

  onSubmit(): void {
    const predicion: Prediction = {
      id: Guid.create(),
      name: this.addPredictionFormGroup.controls.nameFormControl.value,
      amount: this.addPredictionFormGroup.controls.inicialCapitalFormControl.value,
      currency: this.addPredictionFormGroup.controls.currencyFormControl.value,
      startingDate: this.addPredictionFormGroup.controls.dateFormControl.value
    };

    this.addRequest.emit(predicion);
    this.dialogRef.close();
  }
}

