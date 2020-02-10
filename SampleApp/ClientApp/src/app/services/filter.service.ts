import { Injectable } from '@angular/core';
import { FilterKeyValuePair } from '../models/FilterKeyValuePair';
import { FilterType } from '../models/programModel';
import { BaseFilter } from '../models/BaseFilter';
import { SeriesFilter } from '../models/SeriesFilter';
import { DateFilter } from '../models/DateFilter';
import { ScreenFilter } from '../models/ScreenFilter';
import { DatePipe } from '@angular/common';
import { DateFormatPipe } from '../pipes/date-format.pipe';

@Injectable({
    providedIn: 'root'
})
export class FilterService {

    constructor(private datePipe: DateFormatPipe) {}

    getFilter(filter: FilterKeyValuePair): BaseFilter {
        switch (filter.key) {
            case FilterType.Series:
                return new SeriesFilter(filter);
            case FilterType.Date:
                return new DateFilter(filter, this.datePipe);
            case FilterType.Screen:
                return new ScreenFilter(filter);
            default:
                break;
        }
    }
}
