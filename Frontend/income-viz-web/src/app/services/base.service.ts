import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { environment } from '@environments/environment';
import { Guid } from 'guid-typescript';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

export abstract class BaseService {
  private readonly apiUrl = environment.apiUrl;
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      Accept: 'application/json'
    })
  };

  constructor(
    private readonly http: HttpClient
  ) { }

  protected getOne<T>(url: string, id: Guid): Observable<T> {
    return this.http.get<T>(`${this.apiUrl}${url}/${id}`).pipe(
      retry(3),
      catchError(this.handleHttpError)
    );
  }

  protected getAll<T>(url: string, id?: Guid): Observable<T> {
    if (typeof(id) !== 'undefined') {
      return this.http.get<T>(`${this.apiUrl}${url}/${id}`).pipe(
        retry(3),
        catchError(this.handleHttpError)
      );
    }

    return this.http.get<T>(`${this.apiUrl}${url}`).pipe(
      retry(3),
      catchError(this.handleHttpError)
    );
  }

  protected post<T>(url: string, object: T): Observable<any> {
    return this.http.post(`${this.apiUrl}${url}`, object, this.httpOptions).pipe(
      catchError(this.handleHttpError)
    );
  }

  protected delete(url: string, id: Guid): Observable<any> {
    return this.http.delete<any>(`${this.apiUrl}${url}/${id}`).pipe(
      catchError(this.handleHttpError)
    );
  }

  protected put<T>(url: string, object: T): Observable<any> {
    return this.http.put(`${this.apiUrl}${url}`, object, this.httpOptions).pipe(
      catchError(this.handleHttpError)
    );
  }

  private handleHttpError(error: HttpErrorResponse): Observable<never> {
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
