import { Component, input, output } from '@angular/core';
import { CategoryRequest } from '../../models/category-request';
import { FormsModule } from '@angular/forms';
import { CategoriesService } from '../../../services/categories.service';
import { firstValueFrom } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-category-add',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './category-add.component.html',
  styleUrl: './category-add.component.scss',
})
export class CategoryAddComponent {
  public category: CategoryRequest = new CategoryRequest();

  name = input<string>('Name default');
  description = input<string>('Name default');

  nameChange = output<string>();

  constructor(
    private categoriesService: CategoriesService,
    private router: Router,
  ) {}

  addCategory() {
    console.log('category => ', this.category);
    this.nameChange.emit(this.category.name || '');
    firstValueFrom(this.categoriesService.addCategory(this.category)).then(
      (res) => {
        this.router.navigateByUrl('categories');
        console.log('response => ', res);
      },
    );
  }
}
