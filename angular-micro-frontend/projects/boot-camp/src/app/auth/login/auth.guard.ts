import { inject } from '@angular/core'
import { ActivatedRouteSnapshot, CanActivateFn, Router, RouterStateSnapshot } from '@angular/router'
import { CookieService } from 'ngx-cookie-service'
import { jwtDecode } from 'jwt-decode'
import { LoginService } from './services/login.service'

export const authGuard: CanActivateFn = (route: ActivatedRouteSnapshot, state: RouterStateSnapshot) => {
	const cookieService = inject(CookieService)
	const loginService = inject(LoginService)
	const router = inject(Router)
	const hasToken = cookieService.check('Authorization')
	console.log('state => ', state)
	console.log('route => ', route)
	if (hasToken) {
		const token = cookieService.get('Authorization')?.replace('Bearer ', '')
		const decodedToken = jwtDecode(token)
		const expirationTime = new Date(decodedToken.exp! * 1000).getTime()
		const currentTime = new Date().getTime()
		if (currentTime > expirationTime) {
			loginService.logout()
			return router.createUrlTree(['/login'])
		}
		const user = loginService.getUser()

		if (user && !user.roles?.includes('Writer') && state.url.includes('categories')) {
			return router.createUrlTree(['/'])
		}

		return true
	}
	return hasToken
}
