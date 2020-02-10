import { BaseFilter } from './BaseFilter';
import { FilterKeyValuePair } from './FilterKeyValuePair';
import { ProgramModel } from './programModel';

export class ScreenFilter extends BaseFilter {
    constructor(_filter: FilterKeyValuePair) { super(_filter); }

    applyFilter(currentReport: ProgramModel[]): ProgramModel[] {
        return currentReport.filter(p => p.screen.toLocaleLowerCase() === this.filter.value.toLocaleLowerCase());
    }
}
