import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { CalcData, CalcOperation } from './calcdata';

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

  public calculate(data: CalcData): Observable<number>{
    if (data.Operation == CalcOperation.Multiplication)
      return this.multiply(data);
    else
      return throwError("Unsupported calcualtion operation: " + data.Operation);
  }

  private multiply(data: CalcData): Observable<number> {
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
    return throwError(errorMessage);
 }

}
