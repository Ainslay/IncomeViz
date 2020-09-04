import { Component, Input, OnInit } from '@angular/core';
import { ShortTermIncome } from '@interfaces/short-term-income.interface';
import { GetCurrenciesAsStrings } from '@utilities/currencies';

@Component({
  selector: 'app-short-term-incomes-list-item',
  templateUrl: './short-term-incomes-list-item.component.html',
  styleUrls: ['./short-term-incomes-list-item.component.scss']
})
export class ShortTermIncomesListItemComponent implements OnInit {
  @Input() shortTermIncome: ShortTermIncome;
  currencies: string[] = GetCurrenciesAsStrings();

  constructor() { }

  ngOnInit(): void {
  }

}
