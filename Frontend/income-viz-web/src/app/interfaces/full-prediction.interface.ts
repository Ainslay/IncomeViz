import { LongTermExpense } from './long-term-expense.interface';
import { LongTermIncome } from './long-term-income.interface';
import { ShortTermExpense } from './short-term-expense.interface';
import { ShortTermIncome } from './short-term-income.interface';
import { Guid } from 'guid-typescript';

export interface FullPrediction {
    id: Guid;
    name: string;
    startingDate: Date;
    amount: number;
    currency: string;
    shortTermIncomes: ShortTermIncome[];
    longTermIncomes: LongTermIncome[];
    shortTermExpenses: ShortTermExpense[];
    longTermExpenses: LongTermExpense[];
}
