import { Component } from '@angular/core'
import { BlogPostsService } from '../../services/blog-posts.service'
import { BlogPostsModel } from '../../models/blog-posts.model'
import { Subscription } from 'rxjs'

@Component({
	selector: 'app-home',
	standalone: true,
	imports: [],
	templateUrl: './home.component.html',
	styleUrl: './home.component.scss',
})
export class HomeComponent {
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
}
