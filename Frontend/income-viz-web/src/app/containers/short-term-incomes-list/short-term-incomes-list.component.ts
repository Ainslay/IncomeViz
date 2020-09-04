import { Component, Input, OnInit } from '@angular/core';
import { ShortTermIncome } from '@interfaces/short-term-income.interface';
import { Guid } from 'guid-typescript';
import { BehaviorSubject, Observable } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { IncomeService } from './../../services/income.service';

@Component({
  selector: 'app-short-term-incomes-list',
  templateUrl: './short-term-incomes-list.component.html',
  styleUrls: ['./short-term-incomes-list.component.scss']
})
export class ShortTermIncomesListComponent implements OnInit {
  @Input() predictionId: Guid;

  refreshToken$ = new BehaviorSubject(undefined);
  shortTermIncomes$: Observable<ShortTermIncome[]> = this.refreshToken$.pipe(
    switchMap(() => this.incomeService.getShortTermIncomes(this.predictionId))
  );

  constructor(
    private incomeService: IncomeService
  ) { }

  ngOnInit(): void {
  }

}
