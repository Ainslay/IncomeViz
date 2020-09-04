import { Currencies } from '@utilities/currencies';

export interface LongTermIncomeDto {
    predictionId: string;
    name: string;
    startingDate: Date;
    executionDay: number;
    amount: number;
    currency: Currencies;
    effectiveDate: Date;
}
