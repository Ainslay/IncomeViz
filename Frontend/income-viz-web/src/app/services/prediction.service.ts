import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError, BehaviorSubject } from 'rxjs';
import { catchError, retry, switchMap } from 'rxjs/operators';
import { environment } from '@environments/environment';
import { Currencies } from '@utilities/currencies';
import { Prediction } from '@interfaces/prediction.interface';

@Injectable({
  providedIn: 'root'
})
export class PredictionService {
  refreshToken$ = new BehaviorSubject(undefined);
  predictions$: Observable<Prediction[]> = this.refreshToken$.pipe(
    switchMap(() => this.getPredictions())
  );

  constructor(
    private http: HttpClient
  ) { }

  getPredictions(): Observable<Prediction[]> {
    return this.http.get<Prediction[]>(`${environment.apiUrl}/prediction/short-prediction/all`, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    }).pipe(
      retry(3),
      catchError(this.handleError)
    );
  }

  addPrediction(prediction: Prediction): void {
    const predictionDto = { name: prediction.name, amount: prediction.amount,
      currency: Currencies[prediction.currency] , startingDate: prediction.startingDate };

    this.http.post<number>(`${environment.apiUrl}/prediction`, predictionDto, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    }).pipe(
        catchError(this.handleError)
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
        catchError(this.handleError)
      ).subscribe(() => this.refreshToken$.next(undefined));
  }

  private handleError(error: HttpErrorResponse): Observable<never> {
    if (error.error instanceof ErrorEvent) {
      console.error('An error occurred:', error.error.message); // A client-side or network error
    } else {
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error}`);                            // The backend returned an unsuccessful response code.
    }

    return throwError(
      'Something went wrong. Please try again later.');
  }
}
