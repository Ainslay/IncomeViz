import { Component, OnInit, Output, Input, EventEmitter } from '@angular/core';
import { Prediction } from '@interfaces/prediction.interface';

@Component({
  selector: 'app-prediction-top-bar',
  templateUrl: './prediction-top-bar.component.html',
  styleUrls: ['./prediction-top-bar.component.scss']
})
export class PredictionTopBarComponent {
  @Input() prediction: Prediction;
  @Output() deleteRequest: EventEmitter<number> = new EventEmitter<number>();

  constructor() { }

  onClickDelete(): void {
    this.deleteRequest.emit(this.prediction.id);
  }
}
