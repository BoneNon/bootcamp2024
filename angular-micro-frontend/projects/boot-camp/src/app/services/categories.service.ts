import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { CategoriesModel } from '../models/categories.model'
import { environment } from '../../environments/environment'

@Injectable({
	providedIn: 'root',
})
export class CategoriesService {
	constructor(private http: HttpClient) {}

	getCategories() {
		return this.http.get<CategoriesModel[]>(environment.apiUrl + 'Categories')
	}

	deleteCategory(categoryId: string) {
		return this.http.delete(environment.apiUrl + 'Categories/' + categoryId)
	}
}
