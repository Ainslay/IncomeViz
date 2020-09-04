import { Currencies } from '@utilities/currencies';

export interface ShortTermIncomeDto {
    predictionId: string;
    name: string;
    executionDate: Date;
    amount: number;
    currency: Currencies;
}
