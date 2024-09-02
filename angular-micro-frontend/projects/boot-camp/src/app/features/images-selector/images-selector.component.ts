import { Component, output } from '@angular/core'
import { FormsModule } from '@angular/forms'
import { UploadImageModel, UploadImageResponseModel } from '../../models/upload-image.model'
import { UploadImageService } from '../../services/upload-image.service'
import { Subscription } from 'rxjs'

@Component({
	selector: 'app-images-selector',
	standalone: true,
	imports: [FormsModule],
	templateUrl: './images-selector.component.html',
	styleUrl: './images-selector.component.scss',
})
export class ImagesSelectorComponent {
	file: File | undefined = undefined

	model: UploadImageModel = new UploadImageModel()

	images: UploadImageResponseModel[] = []

	onUploadSuccess = output<UploadImageResponseModel>()

	private _getImages?: Subscription

	constructor(private uploadImageService: UploadImageService) {}

	ngOnInit() {
		this.getImages()
	}

	onFileUploadChange(event: Event) {
		const element = event.target as HTMLInputElement
		this.file = element?.files?.[0]
		console.log('file => ', this.file)
	}

	getImages() {
		this._getImages = this.uploadImageService.getImages().subscribe({
			next: (res) => {
				this.images = res
				console.log('images => ', this.images)
			},
		})
	}

	onSelectedImage(image: UploadImageResponseModel) {
		this.onUploadSuccess.emit(image)
	}

	uploadImage() {
		if (this.file) {
			this.model.file = this.file
			this.uploadImageService.uploadImage(this.model).subscribe({
				next: (res) => {
					this.onUploadSuccess.emit(<UploadImageResponseModel>res)
					console.log(res)
				},
			})
		}
	}

	ngOnDestroy() {
		this._getImages?.unsubscribe()
	}
}
