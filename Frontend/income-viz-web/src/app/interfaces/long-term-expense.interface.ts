import { Currencies } from '../../utilities/currencies';
import { Guid } from 'guid-typescript';

export interface LongTermExpense {
    longTermExpenseId: Guid;
    name: string;
    executionDay: number;
    startingDate: Date;
    effectiveDate: Date;
    amount: number;
    currency: Currencies;
}
