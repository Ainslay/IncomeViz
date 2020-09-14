import { dialogWidth } from '@utilities/variables';
import { AddLongTermIncomeDialogComponent } from '@dialogs/add-long-term-income-dialog/add-long-term-income-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { Component, Input } from '@angular/core';
import { LongTermIncome } from '@interfaces/long-term-income.interface';
import { IncomeService } from '@services/income.service';
import { Guid } from 'guid-typescript';
import { BehaviorSubject, Observable } from 'rxjs';
import { switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-long-term-incomes-list',
  templateUrl: './long-term-incomes-list.component.html',
  styleUrls: ['./long-term-incomes-list.component.scss']
})
export class LongTermIncomesListComponent {
  @Input() predictionId: Guid;

  refreshToken$ = new BehaviorSubject(undefined);
  longTermIncomes$: Observable<LongTermIncome[]> = this.refreshToken$.pipe(
    switchMap(() => this.incomeService.getLongTermIncomes(this.predictionId))
  );

  constructor(
    private incomeService: IncomeService,
    private dialog: MatDialog
  ) { }

  deleteLongTermIncome(longTermIncomeId: Guid): void {
    this.incomeService.deleteLongTermIncome(longTermIncomeId)
      .subscribe(() => this.refreshToken$.next(undefined));
  }

  editLongTermIncome(editedIncome: LongTermIncome): void {
    this.incomeService.updateLongTermIncome(editedIncome)
      .subscribe(() => this.refreshToken$.next(undefined));
  }
  openAddLongTermIncomeDialog(): void {
    const dialogRef = this.dialog.open(AddLongTermIncomeDialogComponent, {
      width: dialogWidth
    });

    dialogRef.componentInstance.addRequest.subscribe(
      longTermIncome => this.incomeService.addLongTermIncome(this.predictionId, longTermIncome)
        .subscribe(() => this.refreshToken$.next(undefined))
    );

    dialogRef.afterClosed().subscribe(
      () => dialogRef.componentInstance.addRequest.unsubscribe()
    );
  }
}
