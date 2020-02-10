import { FilterKeyValuePair } from './FilterKeyValuePair';
import { ProgramModel } from './programModel';

export abstract class BaseFilter {
    filter: FilterKeyValuePair;

    constructor(_filter: FilterKeyValuePair) {this.filter = _filter; }
    abstract applyFilter(currentReport: ProgramModel[]): ProgramModel[];
}
