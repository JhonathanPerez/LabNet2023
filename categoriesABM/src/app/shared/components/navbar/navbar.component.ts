import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AddUpdateCategoryComponent } from 'src/app/categories/components/add-update-category/add-update-category.component';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
})
export class NavbarComponent implements OnInit {
  constructor(private _dialog: MatDialog) {}

  ngOnInit(): void {}

  openAddEditEmpForm() {
    const dialogRef = this._dialog.open(AddUpdateCategoryComponent);
    dialogRef.afterClosed().subscribe({
      next: (val) => {},
    });
  }
}
