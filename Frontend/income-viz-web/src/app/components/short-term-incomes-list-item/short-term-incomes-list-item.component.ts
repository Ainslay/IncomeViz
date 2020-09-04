import { Currencies, GetCurrenciesAsStrings } from '@utilities/currencies';
import { ShortTermIncome } from '@interfaces/short-term-income.interface';
import { Component, OnInit, Input } from '@angular/core';

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
