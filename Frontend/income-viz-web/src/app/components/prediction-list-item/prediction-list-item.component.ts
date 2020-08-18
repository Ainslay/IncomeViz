import { Prediction } from './../../interfaces/prediction.interface';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-prediction-list-item',
  templateUrl: './prediction-list-item.component.html',
  styleUrls: ['./prediction-list-item.component.scss']
})
export class PredictionListItemComponent implements OnInit {
  @Input() prediction: Prediction;
  @Output() deleteRequest: EventEmitter<number> = new EventEmitter<number>();

  constructor() { }

  ngOnInit(): void {
  }

  onClickDelete(): void {
    this.deleteRequest.emit(this.prediction.id);
  }
}
