import { Component, OnInit } from '@angular/core';
import { PredictionService } from './../../services/prediction.service';
import { Prediction } from './../../interfaces/prediction.interface';

@Component({
  selector: 'app-predictions-list',
  templateUrl: './predictions-list.component.html',
  styleUrls: ['./predictions-list.component.scss']
})
export class PredictionsListComponent implements OnInit {
  predictions: Prediction[] = [];

  constructor(
    private predictionService: PredictionService
  ) { }

  ngOnInit(): void {
    this.predictions = this.predictionService.getPredictions();
  }

}
