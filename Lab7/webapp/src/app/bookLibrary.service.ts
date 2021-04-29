import {Injectable} from '@angular/core';
import {HttpClient, HttpErrorResponse, HttpHeaders} from '@angular/common/http';

import {Observable, of} from 'rxjs';
import {catchError} from 'rxjs/operators';
import {Book} from './book';

@Injectable({
  providedIn: 'root'
})
export class LibraryService {
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };
  private backendUrl = 'http://localhost/Lab7/back-end/';

  constructor(private http: HttpClient) {
  }

  fetchBooks(authorOf: string, genreOf: string): Observable<Book[]> {
    return this.http.get<Book[]>(this.backendUrl + `browse-books.php?author=${authorOf}&genre=${genreOf}`)
      .pipe(catchError(this.handleError<Book[]>('fetchStudents', []))
      );
  }

  deleteBook(authorOf: string, titleOf: string): Observable<any> {
    return this.http.post(this.backendUrl + `delete-book.php`, {
      author: authorOf,
      title: titleOf}).
    pipe(
      catchError(this.handleError('deleteBook', titleOf)));
  }

  addBook(authorOf: string, titleOf: string, pagesOf: number,
          genreOf: string): Observable<any> {
    return  this.http.post(this.backendUrl + `add-book.php`, {
      author: authorOf,
      title: titleOf,
      pages: pagesOf,
      genre: genreOf
    }).pipe(
      catchError(this.handleError('addBook', titleOf))
    );
  }

  updateBook(authorOf: string, titleOf: string, pagesOf: number,
             genreOf: string): Observable<any> {
    return this.http.post(this.backendUrl + `update-book.php`, {
      author: authorOf,
      title: titleOf,
      pages: pagesOf,
      genre: genreOf
    }).pipe(
      catchError(this.handleError('addBook', titleOf)));
  }

  lendBook(authorOf: string, titleOf: string, lendedOf: string): Observable<any> {
    return this.http.post(this.backendUrl + `lend-book.php`, {
      author: authorOf,
      title: titleOf,
      lended: lendedOf
    }).pipe(
      catchError(this.handleError('addBook', titleOf)));
  }

  private handleError<T>(operation = 'operation', result?: T): (error: HttpErrorResponse) => Observable<T> {
    return (error: HttpErrorResponse): Observable<T> => {
      console.log(error);
      alert(error.error.text);
      return of(result as T);
    };
  }
}
