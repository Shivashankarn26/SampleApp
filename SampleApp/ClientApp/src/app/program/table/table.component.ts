import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { MatTableDataSource, MatPaginator } from '@angular/material';
import { ProgramModel } from '../../models/programModel';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent implements OnInit {

  _dataList: ProgramModel[];
  dataSource: MatTableDataSource<any> = new MatTableDataSource();
  displayedColumns: string[] = ['seriesId', 'date', 'screen', 'views'];

  @Input() dataList: Observable<ProgramModel[]>;
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;

  constructor() { }

  ngOnInit() {
    this.dataList.subscribe(p => {
      this.dataSource.data = p;
      this.paginator.pageIndex = 0;
      this.dataSource.paginator = this.paginator;
    });
  }

}
