import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

// Componentes

import { ListCategoryComponent } from './categories/components/list-category/list-category.component';

const routes: Routes = [
  { path: '', redirectTo: 'listCategories', pathMatch: 'full' },
  { path: 'listCategories', component: ListCategoryComponent },
  { path: '**', redirectTo: 'listCategories', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
