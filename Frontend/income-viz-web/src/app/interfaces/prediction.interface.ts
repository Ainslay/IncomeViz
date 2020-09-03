import { Guid } from 'guid-typescript';

export interface Prediction {
    id: Guid;
    name: string;
    startingDate: Date;
    amount: number;
    currency: string;
  }
