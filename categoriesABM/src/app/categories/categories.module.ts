import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListCategoryComponent } from './components/list-category/list-category.component';
import { SharedModule } from '../shared/shared.module';
import { RouterModule } from '@angular/router';
import { MaterialModule } from '../material/material.module';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { AddUpdateCategoryComponent } from './components/add-update-category/add-update-category.component';
import { AngularToastifyModule, ToastService } from 'angular-toastify';

@NgModule({
  declarations: [AddUpdateCategoryComponent, ListCategoryComponent],
  imports: [
    CommonModule,
    MaterialModule,
    SharedModule,
    RouterModule,
    HttpClientModule,
    ReactiveFormsModule,
    AngularToastifyModule,
  ],
  providers: [ToastService],
})
export class CategoriesModule {}
