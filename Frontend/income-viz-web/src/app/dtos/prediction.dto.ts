import { Currencies } from '@utilities/currencies';

export interface PredictionDto {
    name: string;
    amount: number;
    currency: Currencies;
    startingDate: Date;
}
