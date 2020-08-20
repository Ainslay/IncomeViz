import { Injectable } from '@angular/core';
import { Prediction } from '../interfaces/prediction.interface';
import { HttpClient, HttpResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class PredictionService {
  predictions: Prediction[] = [
    { id: 1, name: 'Test', startingDate: new Date(), amount: 1000, currency: 'PLN' }
  ];

  constructor(
    private http: HttpClient
  ) { }

  getPredictions(): Observable<Prediction[]> {
    return this.http.get<Prediction[]>('https://localhost:44394/api/prediction/short-prediction/all', {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    });
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


