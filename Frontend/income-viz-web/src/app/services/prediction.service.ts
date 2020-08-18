import { Injectable } from '@angular/core';
import { Prediction } from '../interfaces/prediction.interface';

@Injectable({
  providedIn: 'root'
})
export class PredictionService {
  predictions: Prediction[] = [
    { id: 1, name: 'Test', startingDate: new Date(), amount: 1000, currency: 'PLN' }
  ];

  constructor() { }

  getPredictions(): Prediction[] {
    return this.predictions;
  }

  addPrediction(prediction: Prediction): void {
    prediction.id = Math.floor(Math.random() * (1000000 - 3 + 1) + 3);
    this.predictions.push(prediction);
  }

  deletePrediction(predictionId: number): void {
    const predictionToDelete = this.predictions.findIndex((p) => p.id === predictionId);
    this.predictions.splice(predictionToDelete, 1);
  }
}


