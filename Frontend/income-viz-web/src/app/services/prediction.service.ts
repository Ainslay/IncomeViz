import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PredictionDto } from '@dtos/prediction.dto';
import { Prediction } from '@interfaces/prediction.interface';
import { Currencies } from '@utilities/currencies';
import { BehaviorSubject, Observable } from 'rxjs';
import { switchMap } from 'rxjs/operators';
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
    http: HttpClient
  ) { super(http); }

  getShortPrediction(shortPredictionId: string): Observable<Prediction> {
    return this.getOne<Prediction>('prediction/short-prediction', shortPredictionId);
  }

  getPredictions(): Observable<Prediction[]> {
    return this.getAll<Prediction[]>('prediction/short-prediction/all');
  }

  addPrediction(prediction: Prediction): void {
    const predictionDto: PredictionDto = {
      name: prediction.name, amount: prediction.amount,
      currency: Currencies[prediction.currency], startingDate: prediction.startingDate
    };

    this.post<PredictionDto>('prediction', predictionDto)
      .subscribe(() => this.refreshToken$.next(undefined));
  }

  deletePrediction(predictionId: number): void {
    this.delete('prediction', predictionId)
      .subscribe(() => this.refreshToken$.next(undefined));
  }
}
