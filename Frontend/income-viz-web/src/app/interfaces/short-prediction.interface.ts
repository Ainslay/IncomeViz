import { Guid } from 'guid-typescript';

export interface ShortPrediction {
    id: Guid;
    name: string;
    startingDate: Date;
    amount: number;
    currency: string;
  }
