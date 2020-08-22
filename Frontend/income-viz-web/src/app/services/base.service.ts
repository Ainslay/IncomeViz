import { Injectable } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BaseService {

  constructor() { }

  protected handleHttpError(error: HttpErrorResponse): Observable<never> {
    if (error.error instanceof ErrorEvent) {
      console.error('An error occurred:', error.error.message); // A client-side or network error
    } else {
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error}`);                            // The backend returned an unsuccessful response code.
    }

    return throwError(
      'Something went wrong. Please try again later.');
  }
}
