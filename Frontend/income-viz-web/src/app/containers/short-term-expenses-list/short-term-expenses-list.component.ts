import { Component, Input } from '@angular/core';
import { ShortTermExpense } from '@interfaces/short-term-expense.interface';
import { Guid } from 'guid-typescript';
import { BehaviorSubject, Observable } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { ExpenseService } from './../../services/expense.service';

@Component({
  selector: 'app-short-term-expenses-list',
  templateUrl: './short-term-expenses-list.component.html',
  styleUrls: ['./short-term-expenses-list.component.scss']
})
export class ShortTermExpensesListComponent {
  @Input() predictionId: Guid;

  refreshToken$ = new BehaviorSubject(undefined);
  shortTermExpenses$: Observable<ShortTermExpense[]> = this.refreshToken$.pipe(
    switchMap(() => this.expenseService.getShortTermExpenses(this.predictionId))
  );

  constructor(
    private expenseService: ExpenseService
  ) { }

}
