import { Component, Input } from '@angular/core';
import { LongTermExpense } from '@interfaces/long-term-expense.interface';
import { ExpenseService } from '@services/expense.service';
import { Guid } from 'guid-typescript';
import { BehaviorSubject, Observable } from 'rxjs';
import { switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-long-term-expenses-list',
  templateUrl: './long-term-expenses-list.component.html',
  styleUrls: ['./long-term-expenses-list.component.scss']
})
export class LongTermExpensesListComponent {
  @Input() predictionId: Guid;

  refreshToken$ = new BehaviorSubject(undefined);
  longTermExpenses$: Observable<LongTermExpense[]> = this.refreshToken$.pipe(
    switchMap(() => this.expenseService.getLongTermExpenses(this.predictionId))
  );

  constructor(
    private expenseService: ExpenseService
  ) { }

  deleteLongTermExpense(longTermExpenseId: Guid): void {
    this.expenseService.deleteLongTermExpense(longTermExpenseId)
      .subscribe(() => this.refreshToken$.next(undefined));
  }
}
