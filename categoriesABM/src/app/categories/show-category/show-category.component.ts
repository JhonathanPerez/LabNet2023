import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { Category } from '../interfaces/category';
import { CategoryService } from '../services/category.service';

@Component({
  selector: 'app-show-category',
  templateUrl: './show-category.component.html',
  styleUrls: ['./show-category.component.css'],
})
export class ShowCategoryComponent implements OnInit {
  id!: number;
  category!: Category;
  loading: boolean = false;

  routeSub!: Subscription;

  constructor(
    private _categoryService: CategoryService,
    private aRoute: ActivatedRoute
  ) {
    this.id = Number(this.aRoute.snapshot.paramMap.get('id'));
  }

  ngOnInit(): void {
    this.getCategory();
  }

  getCategory() {
    this.loading = true;
    this._categoryService.getCategoriesById(this.id).subscribe((data) => {
      this.category = data;
      this.loading = false;
    });
  }
}
