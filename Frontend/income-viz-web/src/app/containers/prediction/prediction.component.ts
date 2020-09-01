import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PredictionService } from '@services/prediction.service';
import { Guid } from 'guid-typescript';
import { FullPrediction } from '@interfaces/full-prediction.interface';

@Component({
  selector: 'app-prediction',
  templateUrl: './prediction.component.html',
  styleUrls: ['./prediction.component.scss']
})
export class PredictionComponent implements OnInit {
  predictionId: Guid;
  prediction: FullPrediction;

  constructor(
    private route: ActivatedRoute,
    private predictionService: PredictionService,
    private router: Router
    ) { }

  ngOnInit(): void {
    this.predictionId = Guid.parse(this.route.snapshot.paramMap.get('id'));
    console.log(this.predictionId);
    this.predictionService.getFullPrediction(this.predictionId)
      .subscribe(result => {this.prediction = result; console.log(this.prediction); });
  }

  deletePrediction(predictionId: Guid): void {
    this.predictionService.deletePrediction(predictionId);
    this.router.navigateByUrl('dashboard');
  }
}
