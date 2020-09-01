import { Currencies } from '../../utilities/currencies';
import { Guid } from 'guid-typescript';

export interface ShortTermExpense {
    shortTermExpenseId: Guid;
    name: string;
    executionDate: Date;
    amount: number;
    currency: Currencies;
}
