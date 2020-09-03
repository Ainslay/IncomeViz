import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AddPredictionDialogComponent } from '@components/add-prediction-dialog/add-prediction-dialog.component';
import { Prediction } from '@interfaces/prediction.interface';
import { PredictionService } from '@services/prediction.service';
import { dialogWidth } from '@utilities/variables';
import { Guid } from 'guid-typescript';
import { BehaviorSubject, Observable } from 'rxjs';
import { switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-predictions-list',
  templateUrl: './predictions-list.component.html',
  styleUrls: ['./predictions-list.component.scss']
})
export class PredictionsListComponent {
  selectedPredictionId: Guid;

  refreshToken$ = new BehaviorSubject(undefined);
  predictions$: Observable<Prediction[]> = this.refreshToken$.pipe(
    switchMap(() => this.predictionService.getPredictions())
  );

  constructor(
    public predictionService: PredictionService,
    public dialog: MatDialog,
  ) { }

  deletePrediction(id: Guid): void {
    this.predictionService.deletePrediction(id).subscribe(
      () => this.refreshToken$.next(undefined)
    );
  }

  openAddPredictionDialog(): void {
    const dialogRef = this.dialog.open(AddPredictionDialogComponent, {
      width: dialogWidth
    });

    dialogRef.componentInstance.addRequest.subscribe(
      prediction => this.predictionService.addPrediction(prediction).subscribe(
        () => this.refreshToken$.next(undefined)
      ));

    dialogRef.afterClosed().subscribe(
      () => dialogRef.componentInstance.addRequest.unsubscribe()
    );
  }
}
