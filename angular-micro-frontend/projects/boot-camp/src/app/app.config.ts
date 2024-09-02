import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core'
import { provideRouter } from '@angular/router'
import { routes } from './app.routes'
import { HttpClient, provideHttpClient, withInterceptors } from '@angular/common/http'
import { authInterceptor } from './auth/login/auth.interceptor'
import { provideMarkdown } from 'ngx-markdown'

export const appConfig: ApplicationConfig = {
	providers: [
		provideZoneChangeDetection({ eventCoalescing: true }),
		provideRouter(routes),
		provideHttpClient(withInterceptors([authInterceptor])),
		provideMarkdown({ loader: HttpClient }),
	],
}
