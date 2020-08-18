import { Component, OnInit } from '@angular/core';
import { PredictionService } from './../../services/prediction.service';
import { Prediction } from './../../interfaces/prediction.interface';
import { MatDialog } from '@angular/material/dialog';
import { AddPredictionDialogComponent } from '../add-prediction-dialog/add-prediction-dialog.component';

@Component({
  selector: 'app-predictions-list',
  templateUrl: './predictions-list.component.html',
  styleUrls: ['./predictions-list.component.scss']
})
export class PredictionsListComponent implements OnInit {
  predictions: Prediction[] = [];

  constructor(
    private predictionService: PredictionService,
    public dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.getPredictions();
  }

  deletePrediction(id: number): void {
    this.predictionService.deletePrediction(id);
    this.getPredictions();
  }

  getPredictions(): void {
    this.predictions = this.predictionService.getPredictions();
  }

  openAddPredictionDialog(): void {
    const dialogRef = this.dialog.open(AddPredictionDialogComponent, {
      width: '300px'
    });
  }
}
