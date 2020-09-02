import { ShortPrediction } from './../../interfaces/short-prediction.interface';
import { Component, Input, OnInit } from '@angular/core';
import { PredictionService } from '@services/prediction.service';
import { Guid } from 'guid-typescript';
import { Router } from '@angular/router';

@Component({
  selector: 'app-prediction-top-bar',
  templateUrl: './prediction-top-bar.component.html',
  styleUrls: ['./prediction-top-bar.component.scss']
})
export class PredictionTopBarComponent implements OnInit{
  @Input() predictionId: Guid;
  prediction: ShortPrediction;
  isLoading = true;

  constructor(
    private predictionService: PredictionService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.predictionService.getShortPrediction(this.predictionId)
      .subscribe({
          next: result => this.prediction = result,
          complete: () => this.isLoading = false
        });
  }

  deletePrediction(): void {
    this.predictionService.deletePrediction(this.predictionId).subscribe(
      () => this.router.navigateByUrl('dashboard'));
  }
}
