import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { BlogPostsModel, BlogPostsRequestModel } from '../models/blog-posts.model'
import { environment } from '../../environments/environment'

@Injectable({
	providedIn: 'root',
})
export class BlogPostsService {
	constructor(private http: HttpClient) {}

	addBlogPost(blogPost: BlogPostsRequestModel) {
		return this.http.post(environment.apiUrl + 'Blogposts', blogPost)
	}

	getBlogPosts() {
		return this.http.get<BlogPostsModel[]>(environment.apiUrl + 'Blogposts')
	}
}
