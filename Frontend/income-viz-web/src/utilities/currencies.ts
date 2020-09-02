export enum Currencies {
    PLN,
    USD,
    GBP,
    EUR
}

export function GetCurrenciesAsStrings(): string[] {
    const keys = Object.keys(Currencies);
    return keys.slice(keys.length / 2, keys.length);
}
