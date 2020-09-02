import { dialogWidth } from '@utilities/variables';
import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AddPredictionDialogComponent } from '@components/add-prediction-dialog/add-prediction-dialog.component';
import { PredictionService } from '@services/prediction.service';

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
    this.dialog.open(AddPredictionDialogComponent, {
      width: dialogWidth
    });
  }
}
