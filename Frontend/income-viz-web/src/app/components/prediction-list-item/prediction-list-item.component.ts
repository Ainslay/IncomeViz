import { Prediction } from './../../interfaces/prediction.interface';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-prediction-list-item',
  templateUrl: './prediction-list-item.component.html',
  styleUrls: ['./prediction-list-item.component.scss']
})
export class PredictionListItemComponent implements OnInit {
  @Input() prediction: Prediction;
  constructor() { }

  ngOnInit(): void {
  }

}
