import { DialogService } from '@services/dialog.service';
import { Component, Input } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AddLongTermExpenseDialogComponent } from '@dialogs/add-long-term-expense-dialog/add-long-term-expense-dialog.component';
import { LongTermExpense } from '@interfaces/long-term-expense.interface';
import { ExpenseService } from '@services/expense.service';
import { dialogWidth } from '@utilities/variables';
import { Guid } from 'guid-typescript';
import { BehaviorSubject, Observable } from 'rxjs';
import { switchMap, filter, tap } from 'rxjs/operators';

@Component({
  selector: 'app-long-term-expenses-list',
  templateUrl: './long-term-expenses-list.component.html',
  styleUrls: ['./long-term-expenses-list.component.scss']
})
export class LongTermExpensesListComponent {
  @Input() predictionId: Guid;
  refresh$ = new BehaviorSubject(undefined);
  longTermExpenses$: Observable<LongTermExpense[]> = this.refresh$.pipe(
    switchMap(() => this.expenseService.getLongTermExpenses(this.predictionId))
  );

  constructor(
    private expenseService: ExpenseService,
    private dialogService: DialogService
  ) { }

  deleteLongTermExpense(longTermExpenseId: Guid): void {
    this.dialogService.openDeleteConfirmationDialog()
      .pipe(
        filter(result => result === true),
        switchMap(() =>
          this.expenseService.deleteLongTermExpense(longTermExpenseId)
            .pipe(
              tap(() => this.refresh$.next(undefined))
            )
        )
      ).subscribe();
  }

  editLongTermExpense(editedExpense: LongTermExpense): void {
    this.expenseService.updateLongTermExpense(editedExpense)
      .subscribe(() => this.refresh$.next(undefined));
  }

  onAddClick(): void {
    this.dialogService.openAddLongTermExpenseDialog()
      .pipe(
        filter(longTermExpense => longTermExpense !== undefined),
        switchMap(longTermExpense =>
          this.expenseService.addLongTermExpense(this.predictionId, longTermExpense)
            .pipe(
              tap(() => this.refresh$.next(undefined))
            )
        )
      ).subscribe();
  }
}
