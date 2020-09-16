import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ShortTermIncome } from '@interfaces/short-term-income.interface';
import { DialogService } from '@services/dialog.service';
import { GetCurrenciesAsStrings } from '@utilities/currencies';
import { Guid } from 'guid-typescript';
import { filter, tap } from 'rxjs/operators';

@Component({
  selector: 'app-short-term-incomes-list-item',
  templateUrl: './short-term-incomes-list-item.component.html',
  styleUrls: ['./short-term-incomes-list-item.component.scss']
})
export class ShortTermIncomesListItemComponent {
  @Input() shortTermIncome: ShortTermIncome;
  @Output() deleteRequest: EventEmitter<Guid> = new EventEmitter<Guid>();
  @Output() editRequest: EventEmitter<ShortTermIncome> = new EventEmitter<ShortTermIncome>();

  currencies: string[] = GetCurrenciesAsStrings();

  constructor(private dialogService: DialogService) { }

  onDeleteClick(): void {
    this.deleteRequest.emit(this.shortTermIncome.shortTermIncomeId);
  }

  onEditClick(): void {
    this.dialogService.openEditShortTermIncomeDialog(this.shortTermIncome)
    .pipe(
      filter(result => result !== undefined),
      tap(editedIncome => this.editRequest.emit(editedIncome))
    ).subscribe();
  }
}
