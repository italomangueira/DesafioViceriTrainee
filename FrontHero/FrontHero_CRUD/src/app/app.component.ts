import { Component } from '@angular/core';
import { RouterLink, RouterModule, RouterOutlet } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { HeroFormComponent } from './components/hero-form/hero-form.component';
import { HeroListComponent } from './components/hero-list/hero-list.component';
import { HeroManagerComponent } from './components/hero-manager/hero-manager.component';

@Component({
  selector: 'app-root',
  imports: [RouterModule, ReactiveFormsModule, RouterLink],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'FrontHero_CRUD';
}
