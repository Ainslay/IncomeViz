import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ShortTermExpense } from '@interfaces/short-term-expense.interface';
import { DialogService } from '@services/dialog.service';
import { GetCurrenciesAsStrings } from '@utilities/currencies';
import { Guid } from 'guid-typescript';
import { filter, tap } from 'rxjs/operators';

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

  constructor(private dialogService: DialogService) { }

  onDeleteClick(): void {
    this.deleteRequest.emit(this.shortTermExpense.shortTermExpenseId);
  }

  onEditClick(): void {
    this.dialogService.openEditShortTermExpenseDialog(this.shortTermExpense)
      .pipe(
        filter(editedExpense => editedExpense !== undefined),
        tap(editedExpense => this.editRequest.emit(editedExpense))
      ).subscribe();
  }
}
