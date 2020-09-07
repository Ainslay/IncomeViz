import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LongTermExpenseDto } from '@dtos/long-term-expense.dto';
import { ShortTermExpenseDto } from '@dtos/short-term-expense.dto';
import { LongTermExpense } from '@interfaces/long-term-expense.interface';
import { ShortTermExpense } from '@interfaces/short-term-expense.interface';
import { Guid } from 'guid-typescript';
import { Observable } from 'rxjs';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class ExpenseService extends BaseService {

  constructor(
    http: HttpClient
  ) { super(http); }

  getShortTermExpenses(predictionId: Guid): Observable<ShortTermExpense[]> {
    return this.getAll<ShortTermExpense[]>('expense/short-term/all', predictionId);
  }

  getLongTermExpenses(predictionId: Guid): Observable<LongTermExpense[]> {
    return this.getAll<LongTermExpense[]>('expense/long-term/all', predictionId);
  }

  addShortTermExpense(id: Guid, expense: ShortTermExpense): Observable<any> {
    const shortTermExpenseDto: ShortTermExpenseDto = {
      predictionId: id.toString(),
      name: expense.name,
      executionDate: expense.executionDate,
      amount: expense.amount,
      currency: expense.currency
    };

    return this.post<ShortTermExpenseDto>('expense/short-term', shortTermExpenseDto);
  }

  addLongTermExpense(id: Guid, expense: LongTermExpense): Observable<any> {
    const longTermexpenseDto: LongTermExpenseDto = {
      predictionId: id.toString(),
      name: expense.name,
      startingDate: expense.startingDate,
      executionDay: expense.executionDay,
      amount: expense.amount,
      currency: expense.currency,
      effectiveDate: expense.effectiveDate
    };

    return this.post<LongTermExpenseDto>('expense/long-term', longTermexpenseDto);
  }

  updateShortTermExpense(editedExpense: ShortTermExpense): Observable<any> {
    return this.put<ShortTermExpense>('expense/short-term', editedExpense);
  }

  deleteShortTermExpense(expenseId: Guid): Observable<any> {
    return this.delete('expense/short-term', expenseId);
  }

  deleteLongTermExpense(expenseId: Guid): Observable<any> {
    return this.delete('expense/long-term', expenseId);
  }
}
