import { Component, Input } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AddLongTermExpenseDialogComponent } from '@dialogs/add-long-term-expense-dialog/add-long-term-expense-dialog.component';
import { LongTermExpense } from '@interfaces/long-term-expense.interface';
import { ExpenseService } from '@services/expense.service';
import { dialogWidth } from '@utilities/variables';
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
    private expenseService: ExpenseService,
    private dialog: MatDialog
  ) { }

  deleteLongTermExpense(longTermExpenseId: Guid): void {
    this.expenseService.deleteLongTermExpense(longTermExpenseId)
      .subscribe(() => this.refreshToken$.next(undefined));
  }

  editLongTermExpense(editedExpense: LongTermExpense): void {
    this.expenseService.updateLongTermExpense(editedExpense)
      .subscribe(() => this.refreshToken$.next(undefined));
  }

  openAddLongTermExpenseDialog(): void {
    const dialogRef = this.dialog.open(AddLongTermExpenseDialogComponent, {
      width: dialogWidth
    });

    dialogRef.componentInstance.addRequest.subscribe(
      longTermExpense => this.expenseService.addLongTermExpense(this.predictionId, longTermExpense)
        .subscribe(() => this.refreshToken$.next(undefined))
    );

    dialogRef.afterClosed().subscribe(
      () => dialogRef.componentInstance.addRequest.unsubscribe()
    );
  }
}
