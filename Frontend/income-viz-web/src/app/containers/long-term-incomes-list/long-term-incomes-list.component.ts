import { Component, Input } from '@angular/core';
import { LongTermIncome } from '@interfaces/long-term-income.interface';
import { IncomeService } from '@services/income.service';
import { Guid } from 'guid-typescript';
import { BehaviorSubject, Observable } from 'rxjs';
import { switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-long-term-incomes-list',
  templateUrl: './long-term-incomes-list.component.html',
  styleUrls: ['./long-term-incomes-list.component.scss']
})
export class LongTermIncomesListComponent {
  @Input() predictionId: Guid;

  refreshToken$ = new BehaviorSubject(undefined);
  longTermIncomes$: Observable<LongTermIncome[]> = this.refreshToken$.pipe(
    switchMap(() => this.incomeService.getLongTermIncomes(this.predictionId))
  );

  constructor(
    private incomeService: IncomeService
  ) { }

  deleteLongTermIncome(longTermIncomeId: Guid): void {
    this.incomeService.deleteLongTermIncome(longTermIncomeId)
      .subscribe(() => this.refreshToken$.next(undefined));
  }
}
