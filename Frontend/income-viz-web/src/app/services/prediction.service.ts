import { Injectable } from '@angular/core';
import { Prediction } from '../interfaces/prediction.interface';

@Injectable({
  providedIn: 'root'
})
export class PredictionService {
  predictions: Prediction[] = [
    { id: 1, name: 'prediction1', startingDate: new Date(), amount: 20000, currency: 'PLN' },
    { id: 2, name: 'prediction2', startingDate: new Date(), amount: 10000, currency: 'EUR' }
  ];

  constructor() { }

  getPredictions(): Prediction[] {
    return this.predictions;
  }
}


