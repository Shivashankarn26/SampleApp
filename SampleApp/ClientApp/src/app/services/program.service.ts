import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from '../../environments/environment';
import { ProgramModel } from '../models/programModel';

@Injectable({
  providedIn: 'root'
})
export class ProgramService {

  constructor(private http: HttpClient) { }

  public URL = `${environment.apiURL}/programs`;

  private getHttpOptions(): Object {
    return {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
  }

  public add(program: ProgramModel): Observable<number> {
    // const url = this.URL + '/orders/bulkbook/';
    return this.http.post(this.URL, program, this.getHttpOptions())
    .pipe (
      map(response => response as any)
    );
  }

  public delete(program: ProgramModel): Observable<number> {
    // const url = this.URL + '/orders/bulkbook/';
    return this.http.patch(this.URL, program, this.getHttpOptions())
    .pipe (
      map(response => response as any)
    );
  }

  public get(): Observable<ProgramModel[]> {
    return this.http.get(this.URL, this.getHttpOptions())
    .pipe(
      map(response => response as ProgramModel[])
    );
  }
}
