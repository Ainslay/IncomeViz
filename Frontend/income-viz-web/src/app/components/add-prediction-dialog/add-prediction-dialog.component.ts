import { PredictionService } from './../../services/prediction.service';
import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

import { Prediction } from './../../interfaces/prediction.interface';
import { Currencies } from './../../../utilities/currencies';
import { FormControl, Validators, FormGroup } from '@angular/forms';

import { MyErrorStateMatcher } from './../../../utilities/error-state-matcher';

@Component({
  selector: 'app-add-prediction-dialog',
  templateUrl: './add-prediction-dialog.component.html',
  styleUrls: ['./add-prediction-dialog.component.scss']
})
export class AddPredictionDialogComponent {
  prediction: Prediction = { id: 0, name: '', startingDate: new Date(), amount: 0, currency: 'PLN'};
  currencies: string[] = Currencies;

  addPredictionFormGroup = new FormGroup({
    nameFormControl: new FormControl('', [
      Validators.required,
      Validators.maxLength(50)
    ]),
    inicialCapitalFormControl: new FormControl(0, [
      Validators.required,
      Validators.max(999999999),
      Validators.min(0)
    ]),
    dateFormControl: new FormControl('', [
      Validators.required
    ]),
    currencyFormControl: new FormControl('', [
      Validators.required
    ])
  });

  stateMatcher = new MyErrorStateMatcher();

  constructor(
    public dialogRef: MatDialogRef<AddPredictionDialogComponent>,
    private predictionService: PredictionService
  ) { }

  onNoClick(): void {
    this.dialogRef.close();
  }

  onSubmit(): void {
    const predicion: Prediction = {
      id: 0,
      name: this.addPredictionFormGroup.controls['nameFormControl'].value,
      amount: this.addPredictionFormGroup.controls['inicialCapitalFormControl'].value,
      currency: this.addPredictionFormGroup.controls['currencyFormControl'].value,
      startingDate: this.addPredictionFormGroup.controls['dateFormControl'].value
    };
    this.predictionService.addPrediction(predicion);
    this.dialogRef.close();
  }
}

