import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PredictionDto } from '@dtos/prediction.dto';
import { ShortPrediction } from '@interfaces/short-prediction.interface';
import { Currencies } from '@utilities/currencies';
import { Guid } from 'guid-typescript';
import { Observable } from 'rxjs';
import { FullPrediction } from './../interfaces/full-prediction.interface';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class PredictionService extends BaseService {

  constructor(
    http: HttpClient
  ) { super(http); }

  getShortPrediction(shortPredictionId: Guid): Observable<ShortPrediction> {
    return this.getOne<ShortPrediction>('prediction/short-prediction', shortPredictionId);
  }

  getShortPredictions(): Observable<ShortPrediction[]> {
    return this.getAll<ShortPrediction[]>('prediction/short-prediction/all');
  }

  getFullPrediction(predictionId: Guid): Observable<FullPrediction> {
    return this.getOne<FullPrediction>('prediction/full-prediction', predictionId);
  }

  addPrediction(prediction: ShortPrediction): Observable<any> {
    const predictionDto: PredictionDto = {
      name: prediction.name, amount: prediction.amount,
      currency: Currencies[prediction.currency], startingDate: prediction.startingDate
    };

    return this.post<PredictionDto>('prediction', predictionDto);
  }

  deletePrediction(predictionId: Guid): Observable<any> {
    return this.delete('prediction', predictionId);
  }
}
