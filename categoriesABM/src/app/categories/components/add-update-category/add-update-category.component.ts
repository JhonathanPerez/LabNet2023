import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Category } from '../../interfaces/category';
import { CategoryService } from '../../services/category.service';

import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastService } from 'angular-toastify';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-add-update-category',
  templateUrl: './add-update-category.component.html',
  styleUrls: ['./add-update-category.component.css'],
})
export class AddUpdateCategoryComponent implements OnInit {
  loading: boolean = false;
  categoryForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private _categoryService: CategoryService,
    private _dialogRef: MatDialogRef<AddUpdateCategoryComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private _toastService: ToastService
  ) {
    this.categoryForm = this.fb.group({
      categoryName: ['', Validators.required],
      categoryDescription: ['', Validators.required],
    });
  }

  ngOnInit(): void {
    if (this.data) {
      this.categoryForm.setValue({
        categoryName: this.data.CategoryName,
        categoryDescription: this.data.Description,
      });
    }
  }

  onFormSubmit() {
    if (this.categoryForm.valid) {
      if (this.data) {
        const category: Category = {
          CategoryName: this.categoryForm.value.categoryName,
          Description: this.categoryForm.value.categoryDescription,
        };
        this._categoryService
          .updateCategory(this.data.CategoryID, category)
          .subscribe({
            next: () => {
              this._toastService.success('Categoría actualizada exitosamente!');
              this._dialogRef.close(true);
            },
            error: (err: HttpErrorResponse) => {
              this._toastService.error(err.message);
            },
          });
      } else {
        const category: Category = {
          CategoryName: this.categoryForm.value.categoryName,
          Description: this.categoryForm.value.categoryDescription,
        };
        this._categoryService.addCategory(category).subscribe({
          next: () => {
            this._toastService.success('Categoría agregada exitosamente!');
            this._dialogRef.close(true);
          },
          error: (err: HttpErrorResponse) => {
            this._toastService.error(err.message);
          },
        });
      }
    }
  }
}
