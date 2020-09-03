import { Guid } from 'guid-typescript';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Prediction } from '@interfaces/prediction.interface';

@Component({
  selector: 'app-prediction-list-item',
  templateUrl: './prediction-list-item.component.html',
  styleUrls: ['./prediction-list-item.component.scss']
})
export class PredictionListItemComponent {
  @Input() prediction: Prediction;
  @Output() deleteRequest: EventEmitter<Guid> = new EventEmitter<Guid>();

  constructor() { }

  onClickDelete(): void {
    this.deleteRequest.emit(this.prediction.id);
  }
}
