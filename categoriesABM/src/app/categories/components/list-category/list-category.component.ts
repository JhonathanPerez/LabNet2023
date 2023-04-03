import {
  AfterViewInit,
  Component,
  OnDestroy,
  OnInit,
  ViewChild,
} from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Category } from '../../interfaces/category';
import { CategoryService } from '../../services/category.service';
import { Subscription } from 'rxjs';
import { MatDialog } from '@angular/material/dialog';
import { AddUpdateCategoryComponent } from '../add-update-category/add-update-category.component';
import { ToastService } from 'angular-toastify';

@Component({
  selector: 'app-list-category',
  templateUrl: './list-category.component.html',
  styleUrls: ['./list-category.component.css'],
})
export class ListCategoryComponent implements OnInit, AfterViewInit, OnDestroy {
  displayedColumns: string[] = [
    '#',
    'Nombre Categoría',
    'Descripción categoría',
    'Opciones',
  ];
  dataSource = new MatTableDataSource<Category>();
  loading: boolean = false;
  suscription!: Subscription;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    private _categoryService: CategoryService,
    private _dialog: MatDialog,
    private _toastService: ToastService
  ) {}

  ngOnInit(): void {
    this.getCategory();

    this.suscription = this._categoryService.refresh.subscribe(() => {
      this.getCategory();
    });
  }

  ngOnDestroy(): void {
    this.suscription.unsubscribe();
  }

  openEditForm(data: Category) {
    const dialogRef = this._dialog.open(AddUpdateCategoryComponent, {
      data,
    });

    dialogRef.afterClosed().subscribe({
      next: (val) => {
        if (val) {
          this.getCategory();
        }
      },
    });
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

    this._categoryService.deleteCategory(id).subscribe({
      next: () => {
        this._toastService.info('Categoría eliminada exitosamente');
        this.loading = false;
        this.getCategory();
      },
      error: (err: any) => {
        console.log(err);
        this._toastService.error(err);
      },
    });
  }
}
