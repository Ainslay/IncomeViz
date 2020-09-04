import { Component, Input, OnInit } from '@angular/core';
import { LongTermIncome } from '@interfaces/long-term-income.interface';
import { GetCurrenciesAsStrings } from '@utilities/currencies';

@Component({
  selector: 'app-long-term-incomes-list-item',
  templateUrl: './long-term-incomes-list-item.component.html',
  styleUrls: ['./long-term-incomes-list-item.component.scss']
})
export class LongTermIncomesListItemComponent implements OnInit {
  @Input() longTermIncome: LongTermIncome;
  currencies: string[] = GetCurrenciesAsStrings();

  constructor() { }

  ngOnInit(): void {
  }

}
