export class ProgramModel {
    seriesId: string;
    date: Date;
    screen: string;
    views: number;
}

export enum FilterType {
    Series = 'series',
    Date = 'date',
    Screen = 'screen'
}

export class FilterOption {
    query: string;
    type: FilterType;
}

export enum ScreenType {
    TV,
    Mobile,
    Tablet,
    Desktop
}
