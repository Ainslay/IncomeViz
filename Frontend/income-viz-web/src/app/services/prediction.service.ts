import { Guid } from 'guid-typescript';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PredictionDto } from '@dtos/prediction.dto';
import { ShortPrediction } from '@interfaces/short-prediction.interface';
import { Currencies } from '@utilities/currencies';
import { BehaviorSubject, Observable } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class PredictionService extends BaseService {
  refreshToken$ = new BehaviorSubject(undefined);
  predictions$: Observable<ShortPrediction[]> = this.refreshToken$.pipe(
    switchMap(() => this.getShortPredictions())
  );

  constructor(
    http: HttpClient
  ) { super(http); }

  getShortPrediction(shortPredictionId: Guid): Observable<ShortPrediction> {
    return this.getOne<ShortPrediction>('prediction/short-prediction', shortPredictionId);
  }

  getShortPredictions(): Observable<ShortPrediction[]> {
    return this.getAll<ShortPrediction[]>('prediction/short-prediction/all');
  }

  addPrediction(prediction: ShortPrediction): void {
    const predictionDto: PredictionDto = {
      name: prediction.name, amount: prediction.amount,
      currency: Currencies[prediction.currency], startingDate: prediction.startingDate
    };

    this.post<PredictionDto>('prediction', predictionDto)
      .subscribe(() => this.refreshToken$.next(undefined));
  }

  deletePrediction(predictionId: Guid): void {
    this.delete('prediction', predictionId)
      .subscribe(() => this.refreshToken$.next(undefined));
  }
}
