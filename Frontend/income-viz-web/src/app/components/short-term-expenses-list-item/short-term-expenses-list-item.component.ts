import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { EditShortTermExpenseDialogComponent } from '@dialogs/edit-short-term-expense-dialog/edit-short-term-expense-dialog.component';
import { ShortTermExpense } from '@interfaces/short-term-expense.interface';
import { GetCurrenciesAsStrings } from '@utilities/currencies';
import { dialogWidth } from '@utilities/variables';
import { Guid } from 'guid-typescript';

@Component({
  selector: 'app-short-term-expenses-list-item',
  templateUrl: './short-term-expenses-list-item.component.html',
  styleUrls: ['./short-term-expenses-list-item.component.scss']
})
export class ShortTermExpensesListItemComponent {
  @Input() shortTermExpense: ShortTermExpense;
  @Output() deleteRequest: EventEmitter<Guid> = new EventEmitter<Guid>();
  @Output() editRequest: EventEmitter<ShortTermExpense> = new EventEmitter<ShortTermExpense>();

  currencies: string[] = GetCurrenciesAsStrings();

  constructor(private dialog: MatDialog) { }

  onClickDelete(): void {
    this.deleteRequest.emit(this.shortTermExpense.shortTermExpenseId);
  }

  openEditShortTermIncomeDialog(): void {
    this.dialog.open(EditShortTermExpenseDialogComponent, {
      data: this.shortTermExpense,
      width: dialogWidth
    }).afterClosed().subscribe(editedExpense => {
      if (typeof(editedExpense) !== 'undefined') {
        this.editRequest.emit(editedExpense);
      }
    });
  }
}
