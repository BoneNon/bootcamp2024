import { Component } from '@angular/core';
import { CategoriesService } from '../../services/categories.service';
import { firstValueFrom, Subscription } from 'rxjs';
import { CategoriesModel } from '../../models/categories.model';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-categories',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './categories.component.html',
  styleUrl: './categories.component.scss',
})
export class CategoriesComponent {
  private _categories?: Subscription;

  public categories: CategoriesModel[] = [];

  constructor(private categoriesService: CategoriesService) {}

  ngOnInit() {
    this.getCategories();
  }

  getCategories() {
    this._categories = this.categoriesService.getCategories().subscribe({
      next: (categories) => {
        this.categories = categories;
        console.log('this.categories => ', this.categories);
      },
      error: (error) => {
        console.error('error', error);
      },
    });
  }

  deleteCategory(categoryId?: string) {
    if (categoryId) {
      firstValueFrom(this.categoriesService.deleteCategory(categoryId)).then(
        (res) => {
          // this.categories = this.categories.filter((f) => f.id !== categoryId);
          this.getCategories();
          console.log('res => ', res);
        },
      );
    }
  }

  ngOnDestroy() {
    this._categories?.unsubscribe();
  }
}
