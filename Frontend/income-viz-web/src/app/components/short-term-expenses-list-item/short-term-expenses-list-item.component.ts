import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { GetCurrenciesAsStrings } from '@utilities/currencies';
import { ShortTermExpense } from '@interfaces/short-term-expense.interface';
import { Guid } from 'guid-typescript';

@Component({
  selector: 'app-short-term-expenses-list-item',
  templateUrl: './short-term-expenses-list-item.component.html',
  styleUrls: ['./short-term-expenses-list-item.component.scss']
})
export class ShortTermExpensesListItemComponent {
  @Input() shortTermExpense: ShortTermExpense;
  @Output() deleteRequest: EventEmitter<Guid> = new EventEmitter<Guid>();
  currencies: string[] = GetCurrenciesAsStrings();

  constructor() { }

  onClickDelete(): void {
    this.deleteRequest.emit(this.shortTermExpense.shortTermExpenseId);
  }
}
