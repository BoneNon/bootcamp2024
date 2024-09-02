import { Component } from '@angular/core'
import { RouterLink } from '@angular/router'
import { BlogPostsService } from '../../services/blog-posts.service'
import { BlogPostsModel } from '../../models/blog-posts.model'
import { Subscription } from 'rxjs'

@Component({
	selector: 'app-blog-post',
	standalone: true,
	imports: [RouterLink],
	templateUrl: './blog-post.component.html',
	styleUrl: './blog-post.component.scss',
})
export class BlogPostComponent {
	public blogPosts: BlogPostsModel[] = []

	private _blogPosts?: Subscription
	constructor(private blogPostsService: BlogPostsService) {}

	ngOnInit() {
		this._blogPosts = this.blogPostsService.getBlogPosts().subscribe({
			next: (res) => {
				this.blogPosts = res
			},
		})
	}

	ngOnDestroy() {
		this._blogPosts?.unsubscribe()
	}

	deleteBlogPost(id: string) {}
}
