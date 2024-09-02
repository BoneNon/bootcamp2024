import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { LoginRequest, LoginResponse } from '../models/login.model'
import { environment } from '../../../../environments/environment'
import { User } from '../models/user.model'
import { BehaviorSubject } from 'rxjs'
import { CookieService } from 'ngx-cookie-service'
import { Router } from '@angular/router'

@Injectable({
	providedIn: 'root',
})
export class LoginService {
	$user: BehaviorSubject<User | undefined> = new BehaviorSubject<User | undefined>(undefined)

	constructor(
		private http: HttpClient,
		private cookieService: CookieService,
		private router: Router,
	) {}

	login(model: LoginRequest) {
		return this.http.post<LoginResponse>(environment.apiUrl + 'auth/login', model)
	}

	logout() {
		this.cookieService.delete('Authorization', '/')
		localStorage.clear()
		this.$user.next(undefined)
	}

	setUser(user: User) {
		this.$user.next(user)
		localStorage.setItem('user-email', user.email!)
		localStorage.setItem('user-roles', user.roles.join(','))
		this.router.navigateByUrl('/')
	}

	getUser(): User | undefined {
		const email = localStorage.getItem('user-email')
		const roles = localStorage.getItem('user-roles') // '1,2,3' => ['1', '2', '3'] (using split)

		if (email && roles) {
			return {
				email: email,
				roles: roles.split(','),
			}
		}
		return undefined
	}
}
