export class ProgramModel {
    seriesId: string;
    date: Date;
    screen: string;
    views: number;
}

export enum FilterType {
    SeriesId,
    Screen
}

export class FilterOption {
    query: string;
    type: FilterType;
}
