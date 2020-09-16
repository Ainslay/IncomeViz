import { Injectable } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { AddLongTermExpenseDialogComponent } from '@dialogs/add-long-term-expense-dialog/add-long-term-expense-dialog.component';
import { AddLongTermIncomeDialogComponent } from '@dialogs/add-long-term-income-dialog/add-long-term-income-dialog.component';
import { AddPredictionDialogComponent } from '@dialogs/add-prediction-dialog/add-prediction-dialog.component';
import { AddShortTermExpenseDialogComponent } from '@dialogs/add-short-term-expense-dialog/add-short-term-expense-dialog.component';
import { AddShortTermIncomeDialogComponent } from '@dialogs/add-short-term-income-dialog/add-short-term-income-dialog.component';
import { ConfirmDeleteDialogComponent } from '@dialogs/confirm-delete-dialog/confirm-delete-dialog.component';
import { EditLongTermExpenseDialogComponent } from '@dialogs/edit-long-term-expense-dialog/edit-long-term-expense-dialog.component';
import { EditLongTermIncomeDialogComponent } from '@dialogs/edit-long-term-income-dialog/edit-long-term-income-dialog.component';
import { EditPredictionDialogComponent } from '@dialogs/edit-prediction-dialog/edit-prediction-dialog.component';
import { EditShortTermExpenseDialogComponent } from '@dialogs/edit-short-term-expense-dialog/edit-short-term-expense-dialog.component';
import { EditShortTermIncomeDialogComponent } from '@dialogs/edit-short-term-income-dialog/edit-short-term-income-dialog.component';
import { LongTermExpense } from '@interfaces/long-term-expense.interface';
import { LongTermIncome } from '@interfaces/long-term-income.interface';
import { Prediction } from '@interfaces/prediction.interface';
import { ShortTermExpense } from '@interfaces/short-term-expense.interface';
import { ShortTermIncome } from '@interfaces/short-term-income.interface';
import { dialogWidth } from '@utilities/variables';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DialogService {
  basicConfig: MatDialogConfig = {
    width: dialogWidth
  };

  constructor(
    private dialog: MatDialog
  ) { }

  closeAll(): void {
    this.dialog.closeAll();
  }

  openAddPredictionDialog(): Observable<any> {
    return this.dialog.open(AddPredictionDialogComponent, this.basicConfig).afterClosed();
  }

  openAddShortTermExpenseDialog(): Observable<any> {
    return this.dialog.open(AddShortTermExpenseDialogComponent, this.basicConfig).afterClosed();
  }

  openAddShortTermIncomeDialog(): Observable<any> {
    return this.dialog.open(AddShortTermIncomeDialogComponent, this.basicConfig).afterClosed();
  }

  openAddLongTermExpenseDialog(): Observable<any> {
    return this.dialog.open(AddLongTermExpenseDialogComponent, this.basicConfig).afterClosed();
  }

  openAddLongTermIncomeDialog(): Observable<any> {
    return this.dialog.open(AddLongTermIncomeDialogComponent, this.basicConfig).afterClosed();
  }

  openDeleteConfirmationDialog(): Observable<any> {
    return this.dialog.open(ConfirmDeleteDialogComponent, this.basicConfig).afterClosed();
  }

  openEditPredictionDialog(predictionToEdit: Prediction): Observable<any> {
    return this.dialog.open(EditPredictionDialogComponent, {
      data: predictionToEdit,
      width: dialogWidth
    }).afterClosed();
  }

  openEditShortTermIncomeDialog(incomeToEdit: ShortTermIncome): Observable<any> {
    return this.dialog.open(EditShortTermIncomeDialogComponent, {
      data: incomeToEdit,
      width: dialogWidth
    }).afterClosed();
  }

  openEditShortTermExpenseDialog(expenseToEdit: ShortTermExpense): Observable<any> {
    return this.dialog.open(EditShortTermExpenseDialogComponent, {
      data: expenseToEdit,
      width: dialogWidth
    }).afterClosed();
  }

  openEditLongTermIncomeDialog(incomeToEdit: LongTermIncome): Observable<any> {
    return this.dialog.open(EditLongTermIncomeDialogComponent, {
      data: incomeToEdit,
      width: dialogWidth
    }).afterClosed();
  }

  openEditLongTermExpenseDialog(expenseToEdit: LongTermExpense): Observable<any> {
    return this.dialog.open(EditLongTermExpenseDialogComponent, {
      data: expenseToEdit,
      width: dialogWidth
    }).afterClosed();
  }
}
