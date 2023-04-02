import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Category } from '../interfaces/category';
import { CategoryService } from '../services/category.service';

@Component({
  selector: 'app-add-update-category',
  templateUrl: './add-update-category.component.html',
  styleUrls: ['./add-update-category.component.css'],
})
export class AddUpdateCategoryComponent implements OnInit {
  loading: boolean = false;
  form: FormGroup;
  id: number;

  operacion: string = 'Agregar';

  constructor(
    private fb: FormBuilder,
    private _categoryService: CategoryService,
    private _snackBar: MatSnackBar,
    private router: Router,
    private aRoute: ActivatedRoute
  ) {
    this.form = this.fb.group({
      name: ['', Validators.required],
      description: ['', Validators.required],
    });
    this.id = Number(this.aRoute.snapshot.paramMap.get('id'));
  }

  ngOnInit(): void {
    if (this.id != 0) {
      this.operacion = 'Editar';
      this.getCategory(this.id);
    }
  }

  getCategory(id: number) {
    this.loading = true;
    this._categoryService.getCategoriesById(id).subscribe((data) => {
      this.form.setValue({
        name: data.CategoryName,
        description: data.Description,
      });
      this.loading = false;
    });
  }

  addEditCategory() {
    const category: Category = {
      CategoryName: this.form.value.name,
      Description: this.form.value.description,
    };

    if (this.id != 0) {
      category.CategoryId = this.id;
      this.editCategory(this.id, category);
    } else {
      this.addCategory(category);
    }
  }

  editCategory(id: number, category: Category) {
    this.loading = true;
    this._categoryService.updateCategory(id, category).subscribe(() => {
      this.loading = false;
      this.mensajeExito('actualizada');
      this.router.navigate(['/listCategories']);
    });
  }

  addCategory(category: Category) {
    this._categoryService.addCategory(category).subscribe((data) => {
      this.mensajeExito('registrada');
      this.router.navigate(['/listCategories']);
    });
  }

  mensajeExito(texto: string) {
    this._snackBar.open(`La categoría fue ${texto} con exito`, '', {
      duration: 4000,
      horizontalPosition: 'right',
      verticalPosition: 'top',
    });
  }
}
