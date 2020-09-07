import { Component, Input } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AddShortTermIncomeDialogComponent } from '@dialogs/add-short-term-income-dialog/add-short-term-income-dialog.component';
import { ShortTermIncome } from '@interfaces/short-term-income.interface';
import { IncomeService } from '@services/income.service';
import { dialogWidth } from '@utilities/variables';
import { Guid } from 'guid-typescript';
import { BehaviorSubject, Observable } from 'rxjs';
import { switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-short-term-incomes-list',
  templateUrl: './short-term-incomes-list.component.html',
  styleUrls: ['./short-term-incomes-list.component.scss']
})
export class ShortTermIncomesListComponent {
  @Input() predictionId: Guid;

  refreshToken$ = new BehaviorSubject(undefined);
  shortTermIncomes$: Observable<ShortTermIncome[]> = this.refreshToken$.pipe(
    switchMap(() => this.incomeService.getShortTermIncomes(this.predictionId))
  );

  constructor(
    private incomeService: IncomeService,
    private dialog: MatDialog
  ) { }

  deleteShortTermIncome(shortTermIncomeId: Guid): void {
    this.incomeService.deleteShortTermIncome(shortTermIncomeId)
      .subscribe(() => this.refreshToken$.next(undefined));
  }

  editShortTermIncome(editedIncome: ShortTermIncome): void {
    this.incomeService.updateShortTermIncome(editedIncome)
      .subscribe(() => this.refreshToken$.next(undefined));
  }

  openAddShortTermIncomeDialog(): void {
    const dialogRef = this.dialog.open(AddShortTermIncomeDialogComponent, {
      width: dialogWidth
    });

    dialogRef.componentInstance.addRequest.subscribe(
      shortTermIncome => this.incomeService.addShortTermIncome(this.predictionId, shortTermIncome)
        .subscribe(() => this.refreshToken$.next(undefined))
    );

    dialogRef.afterClosed().subscribe(
      () => dialogRef.componentInstance.addRequest.unsubscribe()
    );
  }
}
