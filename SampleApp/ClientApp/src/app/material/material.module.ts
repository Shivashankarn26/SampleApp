import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { MatFormFieldModule,
  MatInputModule,
  MatDatepickerModule,
  MatNativeDateModule,
  MatSelectModule,
  MatButtonModule,
  MatDialogModule,
  MatPaginatorModule,
  MatIconModule} from '@angular/material';
import { MatSliderModule } from '@angular/material/slider';

@NgModule({
  declarations: [],
  exports: [
    CommonModule,
    MatTableModule,
    MatFormFieldModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatSelectModule,
    MatButtonModule,
    MatDialogModule,
    MatSliderModule,
    MatPaginatorModule,
    MatIconModule
  ]
})
export class MaterialModule { }
