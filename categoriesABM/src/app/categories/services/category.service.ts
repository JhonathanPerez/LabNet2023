import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Category } from '../interfaces/category';
@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  private myAppUrl: string = environment.endpoint;
  private _refresh$ = new Subject<void>();

  constructor(private http: HttpClient) {}

  get refresh() {
    return this._refresh$;
  }

  getCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(`${this.myAppUrl}`).pipe(
      catchError((error) => {
        return throwError(() => new Error(error.Message));
      })
    );
  }

  getCategoriesById(id: number): Observable<Category> {
    return this.http.get<Category>(`${this.myAppUrl}/${id}`).pipe(
      catchError((error) => {
        return throwError(() => new Error(error.error.Message));
      })
    );
  }

  deleteCategory(id: number): Observable<void> {
    return this.http.delete<void>(`${this.myAppUrl}/${id}`).pipe(
      catchError((error) => {
        return throwError(() => new Error(error.error.Message));
      })
    );
  }

  addCategory(category: Category): Observable<Category> {
    return this.http.post<Category>(`${this.myAppUrl}`, category).pipe(
      tap(() => {
        this._refresh$.next();
      }),
      catchError((error) => {
        return throwError(() => new Error(error.error));
      })
    );
  }

  updateCategory(id: number, category: Category): Observable<void> {
    return this.http.put<void>(`${this.myAppUrl}/${id}`, category).pipe(
      catchError((error) => {
        return throwError(() => new Error(error.error));
      })
    );
  }
}
