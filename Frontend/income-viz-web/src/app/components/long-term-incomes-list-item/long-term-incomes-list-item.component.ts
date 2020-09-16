import { Component, EventEmitter, Input, Output } from '@angular/core';
import { LongTermIncome } from '@interfaces/long-term-income.interface';
import { DialogService } from '@services/dialog.service';
import { GetCurrenciesAsStrings } from '@utilities/currencies';
import { Guid } from 'guid-typescript';
import { filter, tap } from 'rxjs/operators';

@Component({
  selector: 'app-long-term-incomes-list-item',
  templateUrl: './long-term-incomes-list-item.component.html',
  styleUrls: ['./long-term-incomes-list-item.component.scss']
})
export class LongTermIncomesListItemComponent {
  @Input() longTermIncome: LongTermIncome;
  @Output() deleteRequest: EventEmitter<Guid> = new EventEmitter<Guid>();
  @Output() editRequest: EventEmitter<LongTermIncome> = new EventEmitter<LongTermIncome>();

  currencies: string[] = GetCurrenciesAsStrings();

  constructor(private dialogService: DialogService) { }

  onDeleteClick(): void {
    this.deleteRequest.emit(this.longTermIncome.longTermIncomeId);
  }

  onEditClick(): void {
    this.dialogService.openEditLongTermIncomeDialog(this.longTermIncome)
      .pipe(
        filter(editedIncome => editedIncome !== undefined),
        tap(editedIncome => this.editRequest.emit(editedIncome))
      ).subscribe();
  }
}
