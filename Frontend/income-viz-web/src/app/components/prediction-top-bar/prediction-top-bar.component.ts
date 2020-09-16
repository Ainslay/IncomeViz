import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Prediction } from '@interfaces/prediction.interface';
import { DialogService } from '@services/dialog.service';
import { PredictionService } from '@services/prediction.service';
import { GetCurrenciesAsStrings } from '@utilities/currencies';
import { Guid } from 'guid-typescript';
import { BehaviorSubject, Observable } from 'rxjs';
import { filter, switchMap, tap } from 'rxjs/operators';

@Component({
  selector: 'app-prediction-top-bar',
  templateUrl: './prediction-top-bar.component.html',
  styleUrls: ['./prediction-top-bar.component.scss']
})
export class PredictionTopBarComponent implements OnInit{
  @Input() predictionId: Guid;
  prediction: Prediction;
  isLoading = true;
  refresh$ = new BehaviorSubject(undefined);
  prediction$: Observable<Prediction> = this.refresh$.pipe(
    switchMap(() => this.predictionService.getPrediction(this.predictionId))
  );
  currencies: string[] = GetCurrenciesAsStrings();

  constructor(
    private predictionService: PredictionService,
    private router: Router,
    private dialogService: DialogService
  ) { }

  ngOnInit(): void {
    this.prediction$.subscribe({
      next: result => {
        this.prediction = result;
        this.isLoading = false;
      }
    });
  }

  deletePrediction(): void {
    this.predictionService.deletePrediction(this.predictionId).subscribe(
      () => this.router.navigateByUrl('dashboard'));
  }

  onEditClick(): void {
    this.dialogService.openEditPredictionDialog(this.prediction)
      .pipe(
        filter(editedPrediction => editedPrediction !== undefined),
        switchMap(editedPrediction =>
          this.predictionService.updatePrediction(editedPrediction)
            .pipe(
              tap(() => this.refresh$.next(undefined))
            )
        )
      ).subscribe();
  }
}
