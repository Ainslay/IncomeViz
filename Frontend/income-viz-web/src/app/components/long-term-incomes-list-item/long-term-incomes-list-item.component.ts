import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { EditLongTermIncomeDialogComponent } from '@dialogs/edit-long-term-income-dialog/edit-long-term-income-dialog.component';
import { LongTermIncome } from '@interfaces/long-term-income.interface';
import { GetCurrenciesAsStrings } from '@utilities/currencies';
import { dialogWidth } from '@utilities/variables';
import { Guid } from 'guid-typescript';

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

  constructor(private dialog: MatDialog) { }

  onClickDelete(): void {
    this.deleteRequest.emit(this.longTermIncome.longTermIncomeId);
  }

  openEditLongTermIncomeDialog(): void {
    this.dialog.open(EditLongTermIncomeDialogComponent, {
      data: this.longTermIncome,
      width: dialogWidth
    }).afterClosed().subscribe(editedIncome => {
      if (typeof(editedIncome) !== 'undefined') {
        this.editRequest.emit(editedIncome);
      }
    });
  }
}
