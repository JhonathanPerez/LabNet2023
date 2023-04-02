import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddUpdateCategoryComponent } from './add-update-category/add-update-category.component';
import { ListCategoryComponent } from './list-category/list-category.component';
import { ShowCategoryComponent } from './show-category/show-category.component';
import { SharedModule } from '../shared/shared.module';
import { RouterModule } from '@angular/router';
import { MaterialModule } from '../material/material.module';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AddUpdateCategoryComponent,
    ListCategoryComponent,
    ShowCategoryComponent,
  ],
  imports: [
    CommonModule,
    MaterialModule,
    SharedModule,
    RouterModule,
    HttpClientModule,
    ReactiveFormsModule,
  ],
})
export class CategoriesModule {}
