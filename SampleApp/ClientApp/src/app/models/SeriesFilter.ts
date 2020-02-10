import { BaseFilter } from './BaseFilter';
import { FilterKeyValuePair } from './FilterKeyValuePair';
import { ProgramModel } from './programModel';

export class SeriesFilter extends BaseFilter {
    constructor(_filter: FilterKeyValuePair) { super(_filter); }

    applyFilter(currentReport: ProgramModel[]): ProgramModel[] {
        return currentReport.filter(p => p.seriesId.toLocaleLowerCase().includes(this.filter.value.toLocaleLowerCase()));
    }
}
