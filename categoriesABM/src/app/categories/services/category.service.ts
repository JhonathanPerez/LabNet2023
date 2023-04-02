import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Category } from '../interfaces/category';
import { MatDialog } from '@angular/material/dialog';
import { ErrorModalComponent } from 'src/app/shared/error-modal/error-modal.component';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  private myAppUrl: string = environment.endpoint;

  constructor(private http: HttpClient, private dialog: MatDialog) {}

  getCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(`${this.myAppUrl}`).pipe(
      catchError((error) => {
        this.dialog.open(ErrorModalComponent, {
          data: { errorMessage: error.error },
        });
        return throwError(() => new Error(error.error));
      })
    );
  }

  getCategoriesById(id: number): Observable<Category> {
    return this.http.get<Category>(`${this.myAppUrl}/${id}`).pipe(
      catchError((error) => {
        this.dialog.open(ErrorModalComponent, {
          data: { errorMessage: error.error },
        });
        return throwError(() => new Error(error.error));
      })
    );
  }

  deleteCategory(id: number): Observable<void> {
    return this.http.delete<void>(`${this.myAppUrl}/${id}`).pipe(
      catchError(({ error }) => {
        this.dialog.open(ErrorModalComponent, {
          data: { errorMessage: error.Message },
        });
        return throwError(() => new Error(error.Message));
      })
    );
  }

  addCategory(category: Category): Observable<Category> {
    return this.http.post<Category>(`${this.myAppUrl}`, category).pipe(
      catchError((error) => {
        this.dialog.open(ErrorModalComponent, {
          data: { errorMessage: error.error },
        });
        return throwError(() => new Error(error.error));
      })
    );
  }

  updateCategory(id: number, category: Category): Observable<void> {
    return this.http.put<void>(`${this.myAppUrl}/${id}`, category).pipe(
      catchError((error) => {
        this.dialog.open(ErrorModalComponent, {
          data: { errorMessage: error.error },
        });
        return throwError(() => new Error(error.error));
      })
    );
  }
}
