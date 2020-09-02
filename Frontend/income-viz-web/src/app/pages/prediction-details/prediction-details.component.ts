import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Guid } from 'guid-typescript';

@Component({
  selector: 'app-prediction-details',
  templateUrl: './prediction-details.component.html',
  styleUrls: ['./prediction-details.component.scss']
})
export class PredictionDetailsComponent implements OnInit {
  predictionId: Guid;

  constructor(
    private route: ActivatedRoute
    ) { }

  ngOnInit(): void {
    this.predictionId = Guid.parse(this.route.snapshot.paramMap.get('id'));
  }

}
