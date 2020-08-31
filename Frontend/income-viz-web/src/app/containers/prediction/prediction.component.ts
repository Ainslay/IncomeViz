import { Guid } from 'guid-typescript';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ShortPrediction } from '@interfaces/short-prediction.interface';
import { PredictionService } from '@services/prediction.service';

@Component({
  selector: 'app-prediction',
  templateUrl: './prediction.component.html',
  styleUrls: ['./prediction.component.scss']
})
export class PredictionComponent implements OnInit {
  predictionId: Guid;
  prediction: ShortPrediction;

  constructor(
    private route: ActivatedRoute,
    private predictionService: PredictionService,
    private router: Router
    ) { }

  ngOnInit(): void {
    this.predictionId = Guid.parse(this.route.snapshot.paramMap.get('id'));
    this.predictionService.getShortPrediction(this.predictionId)
      .subscribe(result => this.prediction = result);
  }

  deletePrediction(predictionId: Guid): void {
    this.predictionService.deletePrediction(predictionId);
    this.router.navigateByUrl('dashboard');
  }
}
