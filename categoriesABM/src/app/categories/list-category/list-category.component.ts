import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Category } from '../interfaces/category';
import { CategoryService } from '../services/category.service';

@Component({
  selector: 'app-list-category',
  templateUrl: './list-category.component.html',
  styleUrls: ['./list-category.component.css'],
})
export class ListCategoryComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = ['#', 'name', 'description', 'options'];
  dataSource = new MatTableDataSource<Category>();
  loading: boolean = false;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    private _snackBar: MatSnackBar,
    private _categoryService: CategoryService
  ) {}

  ngOnInit(): void {
    this.getCategory();
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
    if (this.dataSource.data.length > 0) {
      this.paginator._intl.itemsPerPageLabel = 'Items por pagina';
    }
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  getCategory() {
    this.loading = true;
    this._categoryService.getCategories().subscribe((data) => {
      this.loading = false;
      this.dataSource.data = data;
    });
  }

  deleteCategory(id: number) {
    this.loading = true;

    this._categoryService.deleteCategory(id).subscribe(() => {
      this.menssage();
      this.loading = false;
      this.getCategory();
    });
  }

  menssage() {
    this._snackBar.open('La Categoría fue eliminada con exito', '', {
      duration: 4000,
      horizontalPosition: 'right',
      verticalPosition: 'top',
    });
  }
}
