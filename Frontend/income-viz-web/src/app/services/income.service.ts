import { LongTermIncomeDto } from '@dtos/long-term-income.dto';
import { ShortTermIncomeDto } from '@dtos/short-term-income.dto';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { HttpClient } from '@angular/common/http';
import { ShortTermIncome } from '@interfaces/short-term-income.interface';
import { LongTermIncome } from '@interfaces/long-term-income.interface';
import { Guid } from 'guid-typescript';

@Injectable({
  providedIn: 'root'
})
export class IncomeService extends BaseService {

  constructor(
    http: HttpClient
  ) { super(http); }

  getShortTermIncomes(predictionId: Guid): Observable<ShortTermIncome[]> {
    return this.getAll<ShortTermIncome[]>('income/short-term/all', predictionId);
  }

  getLongTermIncomes(predictionId: Guid): Observable<LongTermIncome[]> {
    return this.getAll<LongTermIncome[]>('income/long-term/all', predictionId);
  }

  addShortTermIncome(id: Guid, income: ShortTermIncome): Observable<any> {
    const shortTermIncomeDto: ShortTermIncomeDto = {
      predictionId: id.toString(),
      name: income.name,
      executionDate: income.executionDate,
      amount: income.amount,
      currency: income.currency
    };

    return this.post<ShortTermIncomeDto>('income/short-term', shortTermIncomeDto);
  }

  addLongTermIncome(id: Guid, income: LongTermIncome): Observable<any> {
    const longTermIncomeDto: LongTermIncomeDto = {
      predictionId: id.toString(),
      name: income.name,
      startingDate: income.startingDate,
      executionDay: income.executionDay,
      amount: income.amount,
      currency: income.currency,
      effectiveDate: income.effectiveDate
    };

    return this.post<LongTermIncomeDto>('income/long-term', longTermIncomeDto);
  }

  updateShortTermIncome(editedIncome: ShortTermIncome): Observable<any>
  {
    return this.put<ShortTermIncome>('income/short-term', editedIncome);
  }

  deleteShortTermIncome(incomeId: Guid): Observable<any> {
    return this.delete('income/short-term', incomeId);
  }

  deleteLongTermIncome(incomeId: Guid): Observable<any> {
    return this.delete('income/long-term', incomeId);
  }
}
