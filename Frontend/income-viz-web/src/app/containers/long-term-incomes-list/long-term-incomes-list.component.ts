import { Component, Input } from '@angular/core';
import { LongTermIncome } from '@interfaces/long-term-income.interface';
import { DialogService } from '@services/dialog.service';
import { IncomeService } from '@services/income.service';
import { Guid } from 'guid-typescript';
import { BehaviorSubject, Observable } from 'rxjs';
import { filter, switchMap, tap } from 'rxjs/operators';

@Component({
  selector: 'app-long-term-incomes-list',
  templateUrl: './long-term-incomes-list.component.html',
  styleUrls: ['./long-term-incomes-list.component.scss']
})
export class LongTermIncomesListComponent {
  @Input() predictionId: Guid;

  refresh$ = new BehaviorSubject(undefined);
  longTermIncomes$: Observable<LongTermIncome[]> = this.refresh$.pipe(
    switchMap(() => this.incomeService.getLongTermIncomes(this.predictionId))
  );

  constructor(
    private incomeService: IncomeService,
    private dialogService: DialogService
  ) { }

  deleteLongTermIncome(longTermIncomeId: Guid): void {
    this.incomeService.deleteLongTermIncome(longTermIncomeId)
      .subscribe(() => this.refresh$.next(undefined));
  }

  editLongTermIncome(editedIncome: LongTermIncome): void {
    this.incomeService.updateLongTermIncome(editedIncome)
      .subscribe(() => this.refresh$.next(undefined));
  }

  onAddClick(): void {
    this.dialogService.openAddLongTermIncomeDialog()
      .pipe(
        filter(longTermIncome => longTermIncome !== undefined),
        switchMap(longTermIncome =>
          this.incomeService.addLongTermIncome(this.predictionId, longTermIncome)
            .pipe(
              tap(() => this.refresh$.next(undefined))
            )
        )
      ).subscribe();
  }
}
