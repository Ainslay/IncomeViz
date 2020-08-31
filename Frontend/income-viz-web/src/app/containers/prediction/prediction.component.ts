import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Prediction } from '@interfaces/prediction.interface';
import { PredictionService } from '@services/prediction.service';

@Component({
  selector: 'app-prediction',
  templateUrl: './prediction.component.html',
  styleUrls: ['./prediction.component.scss']
})
export class PredictionComponent implements OnInit {
  predictionId: string;
  prediction: Prediction;

  constructor(
    private route: ActivatedRoute,
    private predictionService: PredictionService,
    private router: Router
    ) { }

  ngOnInit(): void {
    this.predictionId = this.route.snapshot.paramMap.get('id');
    this.predictionService.getShortPrediction(this.predictionId)
      .subscribe(result => this.prediction = result);
  }

  deletePrediction(predictionId: number): void {
    this.predictionService.deletePrediction(predictionId);
    this.router.navigateByUrl('dashboard');
  }
}