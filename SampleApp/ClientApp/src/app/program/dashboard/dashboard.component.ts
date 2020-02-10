import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ProgramModel } from '../../models/ProgramModel';
import { ProgramService } from '../../services/program.service';
import { FilterKeyValuePair } from '../../models/FilterKeyValuePair';
import { BehaviorSubject } from 'rxjs';
import { FilterService } from '../../services/filter.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  public programs: ProgramModel[];
  isLoading: boolean;

  filteredProgramSubject: BehaviorSubject<ProgramModel[]>;

  constructor(private programService: ProgramService,
    private toastrService: ToastrService,
    private filterService: FilterService) { this.filteredProgramSubject = new BehaviorSubject<ProgramModel[]>([]); }

  ngOnInit() {
    this.isLoading = true;
    this.getPrograms();
  }

  getPrograms() {
    this.programs = [];
    this.programService.get().subscribe(response => {
      this.programs = response;
      this.isLoading = false;
      this.filteredProgramSubject.next(this.programs);
      console.log(this.programs);
    }
    , error => {
      this.toastrService.error(error.message);
      this.isLoading = false;
    });
  }

  public applyFilter(filters: FilterKeyValuePair[]) {
    let filteredPrograms = this.programs;
    if (filters.length > 0) {
      filters.forEach(filter => {
        filteredPrograms = this.filterService.getFilter(filter).applyFilter(filteredPrograms);
      });
    }
    this.filteredProgramSubject.next(filteredPrograms);
  }
}
