import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

// Componentes

import { ListCategoryComponent } from '../app/categories/list-category/list-category.component';
import { AddUpdateCategoryComponent } from '../app/categories/add-update-category/add-update-category.component';
import { ShowCategoryComponent } from '../app/categories/show-category/show-category.component';

const routes: Routes = [
  { path: '', redirectTo: 'listCategories', pathMatch: 'full' },
  { path: 'listCategories', component: ListCategoryComponent },
  { path: 'addCategory', component: AddUpdateCategoryComponent },
  { path: 'showCategory/:id', component: ShowCategoryComponent },
  { path: 'editCategory/:id', component: AddUpdateCategoryComponent },
  { path: '**', redirectTo: 'listCategories', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
