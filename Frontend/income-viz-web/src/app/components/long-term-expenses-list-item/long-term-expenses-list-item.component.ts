import { Component, EventEmitter, Input, Output } from '@angular/core';
import { LongTermExpense } from '@interfaces/long-term-expense.interface';
import { GetCurrenciesAsStrings } from '@utilities/currencies';
import { Guid } from 'guid-typescript';

@Component({
  selector: 'app-long-term-expenses-list-item',
  templateUrl: './long-term-expenses-list-item.component.html',
  styleUrls: ['./long-term-expenses-list-item.component.scss']
})
export class LongTermExpensesListItemComponent {
  @Input() longTermExpense: LongTermExpense;
  @Output() deleteRequest: EventEmitter<Guid> = new EventEmitter<Guid>();
  currencies: string[] = GetCurrenciesAsStrings();

  constructor() { }

  onClickDelete(): void {
    this.deleteRequest.emit(this.longTermExpense.longTermExpenseId);
  }
}
