import { Component, Input } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AddShortTermExpenseDialogComponent } from '@dialogs/add-short-term-expense-dialog/add-short-term-expense-dialog.component';
import { ShortTermExpense } from '@interfaces/short-term-expense.interface';
import { ExpenseService } from '@services/expense.service';
import { dialogWidth } from '@utilities/variables';
import { Guid } from 'guid-typescript';
import { BehaviorSubject, Observable } from 'rxjs';
import { switchMap } from 'rxjs/operators';

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
    private expenseService: ExpenseService,
    private dialog: MatDialog
  ) { }

  deleteShortTermExpense(shortTermExpenseId: Guid): void {
    this.expenseService.deleteShortTermExpense(shortTermExpenseId)
      .subscribe(() => this.refreshToken$.next(undefined));
  }

  editShortTermExpense(editedExpense: ShortTermExpense): void {
    this.expenseService.updateShortTermExpense(editedExpense)
      .subscribe(() => this.refreshToken$.next(undefined));
  }

  openAddShortTermExpenseDialog(): void {
    const dialogRef = this.dialog.open(AddShortTermExpenseDialogComponent, {
      width: dialogWidth
    });

    dialogRef.componentInstance.addRequest.subscribe(
      shortTermExpense => this.expenseService.addShortTermExpense(this.predictionId, shortTermExpense)
        .subscribe(() => this.refreshToken$.next(undefined))
    );

    dialogRef.afterClosed().subscribe(
      () => dialogRef.componentInstance.addRequest.unsubscribe()
    );
  }
}
