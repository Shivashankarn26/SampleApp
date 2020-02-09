import { Component, OnInit, ViewChild } from '@angular/core';
import { ProgramModel, FilterOption, FilterType } from '../models/programModel';
import { ProgramService } from '../services/program.service';
import { ToastrService } from 'ngx-toastr';
import { MatTableDataSource, MatPaginator } from '@angular/material';

@Component({
    selector: 'app-fetch-data',
    templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent implements OnInit {

    
    
    constructor(private programService: ProgramService,
        private toastrService: ToastrService) { }

    ngOnInit(): void {
        
        this.getPrograms();
        // this.addProgram();
        // this.deleteProgram();
    }

    getPrograms() {
        // this.programs = [];
        // this.programService.get().subscribe(response => this.dataSource.data = response
        //     // response.map((p: ProgramModel) => this.programs.push(p))
        //     , error => this.toastrService.error(error.message));
    }

    addProgram() {
        const program = this.getProgramModel();
        this.programService.add(program).subscribe(() => this.toastrService.success('Record added successfully.')
            , error => this.toastrService.error(error.message));
    }

    deleteProgram() {
        const program = this.getProgramModel();
        this.programService.delete(program).subscribe(response => {
            if (response > 0) {
                this.toastrService.success(response + ' record deleted successfully.');
            } else {
                this.toastrService.error('No record found to delete.');
            }
        }
            , error => { this.toastrService.error(error.message); console.log(error); });
    }

    getProgramModel(): ProgramModel {
        return {
            seriesId: 'NewSeries',
            date: new Date(),
            screen: 'tv',
            views: 10
        } as ProgramModel;
    }
}

