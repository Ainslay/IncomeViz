import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ShortTermIncome } from '@interfaces/short-term-income.interface';
import { GetCurrenciesAsStrings } from '@utilities/currencies';
import { Guid } from 'guid-typescript';

@Component({
  selector: 'app-short-term-incomes-list-item',
  templateUrl: './short-term-incomes-list-item.component.html',
  styleUrls: ['./short-term-incomes-list-item.component.scss']
})
export class ShortTermIncomesListItemComponent {
  @Input() shortTermIncome: ShortTermIncome;
  @Output() deleteRequest: EventEmitter<Guid> = new EventEmitter<Guid>();
  currencies: string[] = GetCurrenciesAsStrings();

  constructor() { }

  onClickDelete(): void {
    this.deleteRequest.emit(this.shortTermIncome.shortTermIncomeId);
  }
}
