import { Routes } from '@angular/router'
import { authGuard } from './auth/login/auth.guard'

export const routes: Routes = [
	{
		path: 'categories',
		loadComponent: () => import('./features/categories/categories.component').then((m) => m.CategoriesComponent),
		canActivate: [authGuard],
	},
	{
		path: 'categories/add',
		loadComponent: () => import('./features/category-add/category-add.component').then((m) => m.CategoryAddComponent),
		canActivate: [authGuard],
	},
	{
		path: 'blog-post',
		loadComponent: () => import('./features/blog-post/blog-post.component').then((m) => m.BlogPostComponent),
		canActivate: [authGuard],
	},
	{
		path: 'blog-post/add',
		loadComponent: () => import('./features/blog-post-add/blog-post-add.component').then((m) => m.BlogPostAddComponent),
		canActivate: [authGuard],
	},
	{
		path: 'home',
		loadComponent: () => import('./features/home/home.component').then((m) => m.HomeComponent),
	},
	{
		path: 'login',
		loadComponent: () => import('./auth/login/login/login.component').then((m) => m.LoginComponent),
	},
	{
		path: '',
		redirectTo: 'home',
		pathMatch: 'full',
	},
]
