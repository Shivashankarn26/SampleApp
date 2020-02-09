import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from './dashboard/dashboard.component';
import { FilterComponent } from './filter/filter.component';
import { TableComponent } from './table/table.component';
import { Routes, RouterModule } from '@angular/router';
import { MaterialModule } from '../material/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

const routes: Routes = [
{
  path: '',
  component: DashboardComponent
}];

@NgModule({
  declarations: [DashboardComponent, FilterComponent, TableComponent],
  imports: [CommonModule, RouterModule.forChild(routes), MaterialModule,
    FormsModule,
    ReactiveFormsModule,]
})
export class ProgramModule { }
