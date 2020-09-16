import { Component, Input } from '@angular/core';
import { ShortTermExpense } from '@interfaces/short-term-expense.interface';
import { DialogService } from '@services/dialog.service';
import { ExpenseService } from '@services/expense.service';
import { Guid } from 'guid-typescript';
import { BehaviorSubject, Observable } from 'rxjs';
import { filter, switchMap, tap } from 'rxjs/operators';

@Component({
  selector: 'app-short-term-expenses-list',
  templateUrl: './short-term-expenses-list.component.html',
  styleUrls: ['./short-term-expenses-list.component.scss']
})
export class ShortTermExpensesListComponent {
  @Input() predictionId: Guid;

  refresh$ = new BehaviorSubject(undefined);
  shortTermExpenses$: Observable<ShortTermExpense[]> = this.refresh$.pipe(
    switchMap(() => this.expenseService.getShortTermExpenses(this.predictionId))
  );

  constructor(
    private expenseService: ExpenseService,
    private dialogService: DialogService
  ) { }

  deleteShortTermExpense(shortTermExpenseId: Guid): void {
    this.dialogService.openDeleteConfirmationDialog()
      .pipe(
        filter(result => result === true),
        switchMap(() =>
          this.expenseService.deleteShortTermExpense(shortTermExpenseId)
            .pipe(
              tap(() => this.refresh$.next(undefined))
            )
        )
      ).subscribe();
  }

  editShortTermExpense(editedExpense: ShortTermExpense): void {
    this.expenseService.updateShortTermExpense(editedExpense)
      .subscribe(() => this.refresh$.next(undefined));
  }

  onAddClick(): void {
    this.dialogService.openAddShortTermExpenseDialog()
      .pipe(
        filter(shortTermExpense => shortTermExpense !== undefined),
        switchMap(shortTermExpense =>
          this.expenseService.addShortTermExpense(this.predictionId, shortTermExpense)
            .pipe(
              tap(() => this.refresh$.next(undefined))
            )
        )
      ).subscribe();
  }
}
