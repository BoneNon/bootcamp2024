export class LoginRequest {
	email?: string
	password?: string
}

export class LoginResponse {
	email?: string
	token?: string
	roles: string[] = []
}
