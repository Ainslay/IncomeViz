import { Component, EventEmitter, Input, Output } from '@angular/core';
import { LongTermExpense } from '@interfaces/long-term-expense.interface';
import { DialogService } from '@services/dialog.service';
import { GetCurrenciesAsStrings } from '@utilities/currencies';
import { Guid } from 'guid-typescript';
import { filter, tap } from 'rxjs/operators';

@Component({
  selector: 'app-long-term-expenses-list-item',
  templateUrl: './long-term-expenses-list-item.component.html',
  styleUrls: ['./long-term-expenses-list-item.component.scss']
})
export class LongTermExpensesListItemComponent {
  @Input() longTermExpense: LongTermExpense;
  @Output() deleteRequest: EventEmitter<Guid> = new EventEmitter<Guid>();
  @Output() editRequest: EventEmitter<LongTermExpense> = new EventEmitter<LongTermExpense>();
  currencies: string[] = GetCurrenciesAsStrings();

  constructor(private dialogService: DialogService) { }

  onDeleteClick(): void {
    this.deleteRequest.emit(this.longTermExpense.longTermExpenseId);
  }

  onEditClick(): void {
    this.dialogService.openEditLongTermExpenseDialog(this.longTermExpense)
      .pipe(
        filter(editedExpense => editedExpense !== undefined),
        tap(editedExpense => this.editRequest.emit(editedExpense))
      ).subscribe();
  }
}
