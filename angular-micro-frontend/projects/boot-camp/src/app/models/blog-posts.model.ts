export class BlogPostsRequestModel {
	title?: string
	shortDescription?: string
	content?: string
	featuredImageUrl?: string
	urlHandle?: string
	publishedDate?: Date
	author?: string
	isVisible: boolean = false
	categories: string[] = []
}

export class BlogPostsModel {
	id?: string
	title?: string
	shortDescription?: string
	content?: string
	featuredImageUrl?: string
	urlHandle?: string
	publishedDate?: Date
	author?: string
	isVisible: boolean = false
	categories: string[] = []
}
