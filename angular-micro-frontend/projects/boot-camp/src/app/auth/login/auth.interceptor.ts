import { HttpInterceptorFn } from '@angular/common/http'
import { inject } from '@angular/core'
import { CookieService } from 'ngx-cookie-service'

export const authInterceptor: HttpInterceptorFn = (req, next) => {
	const cookieService = inject(CookieService)
	req = req.clone({
		setHeaders: {
			Authorization: `${cookieService.get('Authorization')}`,
		},
	})

	console.log(req)
	return next(req)
}
