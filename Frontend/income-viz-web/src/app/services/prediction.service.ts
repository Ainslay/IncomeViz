import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '@environments/environment';
import { Prediction } from '@interfaces/prediction.interface';
import { Currencies } from '@utilities/currencies';
import { BehaviorSubject, Observable } from 'rxjs';
import { catchError, retry, switchMap } from 'rxjs/operators';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class PredictionService extends BaseService {
  refreshToken$ = new BehaviorSubject(undefined);
  predictions$: Observable<Prediction[]> = this.refreshToken$.pipe(
    switchMap(() => this.getPredictions())
  );

  constructor(
    private http: HttpClient
  ) { super(); }

  getPredictions(): Observable<Prediction[]> {
    return this.http.get<Prediction[]>(`${environment.apiUrl}/prediction/short-prediction/all`, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    }).pipe(
      retry(3),
      catchError(this.handleHttpError)
    );
  }

  addPrediction(prediction: Prediction): void {
    const predictionDto = {
      name: prediction.name, amount: prediction.amount,
      currency: Currencies[prediction.currency], startingDate: prediction.startingDate
    };

    this.http.post<number>(`${environment.apiUrl}/prediction`, predictionDto, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    }).pipe(
      catchError(this.handleHttpError)
    ).subscribe(() => this.refreshToken$.next(undefined));
  }

  deletePrediction(predictionId: number): void {
    const options = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
      body: {
        id: predictionId
      }
    };

    this.http.delete(`${environment.apiUrl}/prediction`, options)
      .pipe(
        catchError(this.handleHttpError)
      ).subscribe(() => this.refreshToken$.next(undefined));
  }
}
