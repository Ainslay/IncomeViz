import { dialogWidth } from '@utilities/variables';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { EditShortTermIncomeDialogComponent } from '@dialogs/edit-short-term-income-dialog/edit-short-term-income-dialog.component';
import { ShortTermIncome } from '@interfaces/short-term-income.interface';
import { GetCurrenciesAsStrings } from '@utilities/currencies';
import { Guid } from 'guid-typescript';

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

  constructor(private dialog: MatDialog) { }

  onClickDelete(): void {
    this.deleteRequest.emit(this.shortTermIncome.shortTermIncomeId);
  }

  openEditShortTermIncomeDialog(): void {
    this.dialog.open(EditShortTermIncomeDialogComponent, {
      data: this.shortTermIncome,
      width: dialogWidth
    }).afterClosed().subscribe(editedIncome => {
      if (typeof(editedIncome) !== 'undefined') {
        this.editRequest.emit(editedIncome);
      }
    });
  }
}
