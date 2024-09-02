import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CategoryRequest } from '../src/models/category-request';

@Injectable({
  providedIn: 'root',
})
export class CategoriesService {
  constructor(private http: HttpClient) {}

  addCategory(category: CategoryRequest) {
    return this.http.post(
      'https://dev.tks.co.th/codepulseapi2/api/Categories',
      category,
    );
  }
}
