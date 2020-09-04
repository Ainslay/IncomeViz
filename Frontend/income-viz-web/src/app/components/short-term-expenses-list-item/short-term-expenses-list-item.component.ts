import { Component, Input, OnInit } from '@angular/core';
import { GetCurrenciesAsStrings } from '@utilities/currencies';
import { ShortTermExpense } from '@interfaces/short-term-expense.interface';

@Component({
  selector: 'app-short-term-expenses-list-item',
  templateUrl: './short-term-expenses-list-item.component.html',
  styleUrls: ['./short-term-expenses-list-item.component.scss']
})
export class ShortTermExpensesListItemComponent implements OnInit {
  @Input() shortTermExpense: ShortTermExpense;
  currencies: string[] = GetCurrenciesAsStrings();

  constructor() { }

  ngOnInit(): void {
  }

}
