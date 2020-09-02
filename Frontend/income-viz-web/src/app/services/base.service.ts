import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { environment } from '@environments/environment';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

export abstract class BaseService {
  private readonly apiUrl = environment.apiUrl;
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Accept': 'application/json'
    })
  };
  constructor(
    private readonly http: HttpClient
  ) { }

  protected get<T>(url: string): Observable<T> {
    return this.http.get<T>(`${this.apiUrl}${url}`, this.httpOptions).pipe(
      retry(3),
      catchError(this.handleHttpError)
    );
  }

  protected post<T>(url: string, object: T): Observable<any> {
    return this.http.post(`${this.apiUrl}${url}`, object, this.httpOptions).pipe(
      catchError(this.handleHttpError)
    );
  }

  protected delete(url: string, objectId: number): Observable<any> {
    const options = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
      body: {
        id: objectId
      }
    };

    return this.http.delete(`${this.apiUrl}${url}`, options).pipe(
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
