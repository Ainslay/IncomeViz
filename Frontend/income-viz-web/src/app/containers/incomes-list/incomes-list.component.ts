import { LongTermIncome } from './../../interfaces/long-term-income.interface';
import { ShortTermIncome } from './../../interfaces/short-term-income.interface';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-incomes-list',
  templateUrl: './incomes-list.component.html',
  styleUrls: ['./incomes-list.component.scss']
})
export class IncomesListComponent implements OnInit {
  @Input() shortTermIncomes: ShortTermIncome[];
  @Input() longTermIncomes: LongTermIncome[];

  constructor() { }

  ngOnInit(): void {
  }

}
