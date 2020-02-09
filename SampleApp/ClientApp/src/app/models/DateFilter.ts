import { BaseFilter } from './BaseFilter';
import { FilterKeyValuePair } from './FilterKeyValuePair';
import { ProgramModel } from './programModel';
import { DatePipe } from '@angular/common';

export class DateFilter extends BaseFilter {
    constructor(_filter: FilterKeyValuePair, private datePipe: DatePipe) { super(_filter); }

    applyFilter(currentReport: ProgramModel[]): ProgramModel[] {
        return currentReport.filter(p => this.datePipe.transform(p.date) === this.datePipe.transform(this.filter.value));
    }
}
