import { Component, Input } from '@angular/core';
import { ShortTermIncome } from '@interfaces/short-term-income.interface';
import { DialogService } from '@services/dialog.service';
import { IncomeService } from '@services/income.service';
import { Guid } from 'guid-typescript';
import { BehaviorSubject, Observable } from 'rxjs';
import { filter, switchMap, tap } from 'rxjs/operators';

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
    private dialogService: DialogService
  ) { }

  deleteShortTermIncome(shortTermIncomeId: Guid): void {
    this.incomeService.deleteShortTermIncome(shortTermIncomeId)
      .subscribe(() => this.refreshToken$.next(undefined));
  }

  editShortTermIncome(editedIncome: ShortTermIncome): void {
    this.incomeService.updateShortTermIncome(editedIncome)
      .subscribe(() => this.refreshToken$.next(undefined));
  }

  onAddClick(): void {
    this.dialogService.openAddShortTermIncomeDialog()
      .pipe(
        filter(shortTermIncome => shortTermIncome !== undefined),
        switchMap(shortTermIncome =>
          this.incomeService.addShortTermIncome(this.predictionId, shortTermIncome)
            .pipe(
              tap(() => this.refreshToken$.next(undefined))
            )
        )
      ).subscribe();
  }
}
