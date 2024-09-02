import { Component } from '@angular/core'
import { FormsModule } from '@angular/forms'
import { BlogPostsRequestModel } from '../../models/blog-posts.model'
import { CategoriesService } from '../../services/categories.service'
import { firstValueFrom, Subscription } from 'rxjs'
import { CategoriesModel } from '../../models/categories.model'
import { BlogPostsService } from '../../services/blog-posts.service'
import { Router } from '@angular/router'
import { MarkdownModule } from 'ngx-markdown'
import { ImagesSelectorComponent } from '../images-selector/images-selector.component'
import { UploadImageResponseModel } from '../../models/upload-image.model'

@Component({
	selector: 'app-blog-post-add',
	standalone: true,
	imports: [FormsModule, MarkdownModule, ImagesSelectorComponent],
	templateUrl: './blog-post-add.component.html',
	styleUrl: './blog-post-add.component.scss',
})
export class BlogPostAddComponent {
	blogPostAdd: BlogPostsRequestModel = new BlogPostsRequestModel()
	categories: CategoriesModel[] = []

	displayDialogUploadImage: boolean = false

	private _addBlogPost?: Subscription
	constructor(
		private categoriesService: CategoriesService,
		private blogPostService: BlogPostsService,
		private router: Router,
	) {}
	ngOnInit() {
		firstValueFrom(this.categoriesService.getCategories()).then((res) => {
			this.categories = res
		})
	}
	submitForm() {
		this._addBlogPost = this.blogPostService.addBlogPost(this.blogPostAdd).subscribe({
			next: () => {
				this.router.navigateByUrl('/blog-post')
			},
		})
	}

	openDialogUploadImage() {
		this.displayDialogUploadImage = true
	}

	closeDialogUpload() {
		this.displayDialogUploadImage = false
	}

	onUpImage(event: UploadImageResponseModel) {
		this.blogPostAdd.featuredImageUrl = event.url
		this.closeDialogUpload()
	}

	ngOnDestroy() {
		this._addBlogPost?.unsubscribe()
	}
}
