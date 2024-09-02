export class UploadImageModel {
	file: File | undefined = undefined
	fileName?: string
	title?: string
}

export class UploadImageResponseModel {
	url?: string
	fileName?: string
	title?: string
}
