import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AddPredictionDialogComponent } from '@components/add-prediction-dialog/add-prediction-dialog.component';
import { ShortPrediction } from '@interfaces/short-prediction.interface';
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
  predictions$: Observable<ShortPrediction[]> = this.refreshToken$.pipe(
    switchMap(() => this.predictionService.getShortPredictions())
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
