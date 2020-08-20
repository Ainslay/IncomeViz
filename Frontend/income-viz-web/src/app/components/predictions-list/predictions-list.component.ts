import { Component, OnInit } from '@angular/core';
import { PredictionService } from './../../services/prediction.service';
import { Prediction } from './../../interfaces/prediction.interface';
import { MatDialog } from '@angular/material/dialog';
import { AddPredictionDialogComponent } from '../add-prediction-dialog/add-prediction-dialog.component';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-predictions-list',
  templateUrl: './predictions-list.component.html',
  styleUrls: ['./predictions-list.component.scss']
})
export class PredictionsListComponent {
  constructor(
    public predictionService: PredictionService,
    public dialog: MatDialog
  ) { }

  deletePrediction(id: number): void {
    this.predictionService.deletePrediction(id);
  }

  openAddPredictionDialog(): void {
    const dialogRef = this.dialog.open(AddPredictionDialogComponent, {
      width: '300px'
    });
  }
}
