import { Component } from '@angular/core';
import { Prediction } from '@interfaces/prediction.interface';
import { DialogService } from '@services/dialog.service';
import { PredictionService } from '@services/prediction.service';
import { Guid } from 'guid-typescript';
import { BehaviorSubject, Observable } from 'rxjs';
import { filter, switchMap, tap } from 'rxjs/operators';

@Component({
  selector: 'app-predictions-list',
  templateUrl: './predictions-list.component.html',
  styleUrls: ['./predictions-list.component.scss'],
})
export class PredictionsListComponent {
  selectedPredictionId: Guid;

  private refresh$ = new BehaviorSubject(undefined);
  predictions$: Observable<Prediction[]> = this.refresh$.pipe(
    switchMap(() => this.predictionService.getPredictions())
  );

  constructor(
    public predictionService: PredictionService,
    public dialogService: DialogService
  ) {}

  deletePrediction(id: Guid): void {
    this.dialogService.openDeleteConfirmationDialog()
      .pipe(
        filter((result) => result === true),
        switchMap(() =>
          this.predictionService.deletePrediction(id).pipe(
            tap(() => {
              this.refresh$.next(undefined);
            })
          )
        )
      ).subscribe();
  }

  onAddClick(): void {
    this.dialogService.openAddPredictionDialog()
      .pipe(
        filter((result) => result !== undefined),
        switchMap((prediction) =>
          this.predictionService.addPrediction(prediction).pipe(
            tap(() => {
              this.refresh$.next(undefined);
            })
          )
        )
      ).subscribe();
  }
}
