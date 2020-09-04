import { Currencies } from '@utilities/currencies';

export interface ShortTermExpenseDto {
    predictionId: string;
    name: string;
    executionDate: Date;
    amount: number;
    currency: Currencies;
}
