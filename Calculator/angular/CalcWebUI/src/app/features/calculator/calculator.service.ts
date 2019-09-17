import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { CalcData } from './calcdata';

@Injectable({
  providedIn: 'root'
})
export class CalculatorService {

  private apiURL = 'http://localhost:5005';
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  } 

  constructor(private http: HttpClient) { }


  public multiply(data: CalcData): Observable<number> {
    return this.http.post<number>(this.apiURL + '/api/calc', data, this.httpOptions)
    .pipe(
      retry(1),
      catchError(this.handleError)
    );
  }


  private handleError(error) {
    let errorMessage = '';
    if(error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    window.alert(errorMessage);
    return throwError(errorMessage);
 }

}
