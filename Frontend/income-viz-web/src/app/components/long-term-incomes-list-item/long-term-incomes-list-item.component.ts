import { Component, EventEmitter, Input, Output } from '@angular/core';
import { LongTermIncome } from '@interfaces/long-term-income.interface';
import { GetCurrenciesAsStrings } from '@utilities/currencies';
import { Guid } from 'guid-typescript';

@Component({
  selector: 'app-long-term-incomes-list-item',
  templateUrl: './long-term-incomes-list-item.component.html',
  styleUrls: ['./long-term-incomes-list-item.component.scss']
})
export class LongTermIncomesListItemComponent {
  @Input() longTermIncome: LongTermIncome;
  @Output() deleteRequest: EventEmitter<Guid> = new EventEmitter<Guid>();
  currencies: string[] = GetCurrenciesAsStrings();

  constructor() { }

  onClickDelete(): void {
    this.deleteRequest.emit(this.longTermIncome.longTermIncomeId);
  }
}
