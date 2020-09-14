import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { EditLongTermExpenseDialogComponent } from '@dialogs/edit-long-term-expense-dialog/edit-long-term-expense-dialog.component';
import { LongTermExpense } from '@interfaces/long-term-expense.interface';
import { GetCurrenciesAsStrings } from '@utilities/currencies';
import { dialogWidth } from '@utilities/variables';
import { Guid } from 'guid-typescript';

@Component({
  selector: 'app-long-term-expenses-list-item',
  templateUrl: './long-term-expenses-list-item.component.html',
  styleUrls: ['./long-term-expenses-list-item.component.scss']
})
export class LongTermExpensesListItemComponent {
  @Input() longTermExpense: LongTermExpense;
  @Output() deleteRequest: EventEmitter<Guid> = new EventEmitter<Guid>();
  @Output() editRequest: EventEmitter<LongTermExpense> = new EventEmitter<LongTermExpense>()
  currencies: string[] = GetCurrenciesAsStrings();

  constructor(private dialog: MatDialog) { }

  onClickDelete(): void {
    this.deleteRequest.emit(this.longTermExpense.longTermExpenseId);
  }

  openEditLongTermExpenseDialog(): void {
    this.dialog.open(EditLongTermExpenseDialogComponent, {
      data: this.longTermExpense,
      width: dialogWidth
    }).afterClosed().subscribe(editedIncome => {
      if (typeof(editedIncome) !== 'undefined') {
        this.editRequest.emit(editedIncome);
      }
    });
  }
}
