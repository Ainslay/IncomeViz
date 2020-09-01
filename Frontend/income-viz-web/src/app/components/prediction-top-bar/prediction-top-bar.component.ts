import { Guid } from 'guid-typescript';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ShortPrediction } from '@interfaces/short-prediction.interface';

@Component({
  selector: 'app-prediction-top-bar',
  templateUrl: './prediction-top-bar.component.html',
  styleUrls: ['./prediction-top-bar.component.scss']
})
export class PredictionTopBarComponent {
  @Input() prediction: ShortPrediction;
  @Output() deleteRequest: EventEmitter<Guid> = new EventEmitter<Guid>();

  constructor() { }

  onClickDelete(): void {
    this.deleteRequest.emit(this.prediction.id);
  }
}
