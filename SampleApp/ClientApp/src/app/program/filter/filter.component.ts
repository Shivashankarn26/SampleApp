import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { FilterKeyValuePair } from '../../models/FilterKeyValuePair';
import { ScreenType, FilterType } from '../../models/programModel';
import { MatDatepickerInputEvent } from '@angular/material';

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.css']
})
export class FilterComponent implements OnInit {

  filterForm: FormGroup;
  appliedFilters: FilterKeyValuePair[] = [];
  @Output() filterChanged: EventEmitter<any> = new EventEmitter();

  screenList = [{id: 1, value: 'TV'}, {id: 2, value: 'Mobile'}, {id: 3, value: 'Tablet'}, {id: 4, value: 'Desktop'}];
  constructor(private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.intializeEmptyForm();
  }

  private intializeEmptyForm() {
    this.filterForm = this.formBuilder.group({
      series: new FormControl(''),
      date: new FormControl(''),
      screen: new FormControl()
    });
  }

  applyFilter(controlName: string, event: any) {
    let value: string;
    switch (controlName) {
      case FilterType.Series:
        value = this.filterForm.controls[controlName].value;
        break;
      case FilterType.Date:
        event = event as MatDatepickerInputEvent<Date>;
        if (event.value == null) {
          this.clearField(controlName);
        } else {
          value = event.value.toISOString();
        }
        break;
      case FilterType.Screen:
        value = this.screenList.find(s => s.id === +this.filterForm.controls[controlName].value).value;
    }
    if (value != null) {
      const filter = {
        key: controlName,
        value: value
      } as FilterKeyValuePair;
      this.appliedFilters = this.appliedFilters.filter(f => f.key !== filter.key);
      this.appliedFilters.push(filter);
      this.filterChanged.emit(this.appliedFilters);
    }
  }

  clearField(controlName: string) {
    this.filterForm.controls[controlName].setValue('');
    this.appliedFilters = this.appliedFilters.filter(f => f.key !== controlName);
    this.filterChanged.emit(this.appliedFilters);
  }
}
