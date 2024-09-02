import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CategoryAddComponent } from '../features/category-add/category-add.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CategoryAddComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent {
  title = 'micro-front-end';
}
