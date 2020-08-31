import { Guid } from 'guid-typescript';

export interface FullPrediction {
    id: Guid;
    name: string;
    startingDate: Date;
    amount: number;
    currency: string;
}
