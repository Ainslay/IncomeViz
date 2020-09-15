import { MatDialog } from '@angular/material/dialog';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PredictionDto } from '@dtos/prediction.dto';
import { Prediction } from '@interfaces/prediction.interface';
import { Currencies } from '@utilities/currencies';
import { Guid } from 'guid-typescript';
import { Observable } from 'rxjs';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class PredictionService extends BaseService {

  constructor(
    http: HttpClient,
    dialog: MatDialog
  ) { super(http, dialog); }

  getPrediction(predictionId: Guid): Observable<Prediction> {
    return this.getOne<Prediction>('prediction', predictionId);
  }

  getPredictions(): Observable<Prediction[]> {
    return this.getAll<Prediction[]>('prediction/all');
  }

  addPrediction(prediction: Prediction): Observable<any> {
    const predictionDto: PredictionDto = {
      name: prediction.name, amount: prediction.amount,
      currency: Currencies[prediction.currency], startingDate: prediction.startingDate
    };

    return this.post<PredictionDto>('prediction', predictionDto);
  }

  updatePrediction(editedPrediciton: Prediction): Observable<any> {
    return this.put<Prediction>('prediction', editedPrediciton);
  }

  deletePrediction(predictionId: Guid): Observable<any> {
    return this.delete('prediction', predictionId);
  }
}
