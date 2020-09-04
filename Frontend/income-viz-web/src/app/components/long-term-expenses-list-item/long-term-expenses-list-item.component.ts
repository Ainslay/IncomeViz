import { Component, Input, OnInit } from '@angular/core';
import { LongTermExpense } from '@interfaces/long-term-expense.interface';
import { GetCurrenciesAsStrings } from '@utilities/currencies';

@Component({
  selector: 'app-long-term-expenses-list-item',
  templateUrl: './long-term-expenses-list-item.component.html',
  styleUrls: ['./long-term-expenses-list-item.component.scss']
})
export class LongTermExpensesListItemComponent implements OnInit {
  @Input() longTermExpense: LongTermExpense;
  currencies: string[] = GetCurrenciesAsStrings();

  constructor() { }

  ngOnInit(): void {
  }

}
