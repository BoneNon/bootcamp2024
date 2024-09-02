import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { UploadImageModel, UploadImageResponseModel } from '../models/upload-image.model'
import { environment } from '../../environments/environment'

@Injectable({
	providedIn: 'root',
})
export class UploadImageService {
	constructor(private http: HttpClient) {}

	uploadImage(model: UploadImageModel) {
		const formDate = new FormData()
		formDate.append('file', model.file!)
		formDate.append('title', model.title!)
		formDate.append('fileName', model.fileName!)
		return this.http.post(environment.apiUrl + 'Images', formDate)
	}

	getImages() {
		return this.http.get<UploadImageResponseModel[]>(environment.apiUrl + 'Images')
	}
}
