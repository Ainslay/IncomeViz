import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { EditPredictionDialogComponent } from '@dialogs/edit-prediction-dialog/edit-prediction-dialog.component';
import { Prediction } from '@interfaces/prediction.interface';
import { PredictionService } from '@services/prediction.service';
import { dialogWidth } from '@utilities/variables';
import { Guid } from 'guid-typescript';
import { BehaviorSubject, Observable } from 'rxjs';
import { switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-prediction-top-bar',
  templateUrl: './prediction-top-bar.component.html',
  styleUrls: ['./prediction-top-bar.component.scss']
})
export class PredictionTopBarComponent implements OnInit {
  @Input() predictionId: Guid;
  prediction: Prediction;
  isLoading = true;
  refreshToken$ = new BehaviorSubject(undefined);
  prediction$: Observable<Prediction>;

  constructor(
    private predictionService: PredictionService,
    private router: Router,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.prediction$ = this.refreshToken$.pipe(
      switchMap(() => this.predictionService.getPrediction(this.predictionId))
    );

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

  openEditPredictionDialog(): void {
    this.dialog.open(EditPredictionDialogComponent, {
      data: this.prediction,
      width: dialogWidth
    }).afterClosed().subscribe(editedPrediction => {
      if (typeof(editedPrediction) !== 'undefined') {
        this.predictionService.updatePrediction(editedPrediction)
          .subscribe(() => this.refreshToken$.next(undefined));
      }
    });
  }
}
