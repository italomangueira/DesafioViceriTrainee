import { Component } from '@angular/core';
import { HeroFormComponent } from '../hero-form/hero-form.component';
import { HeroListComponent } from '../hero-list/hero-list.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-hero-manager',
  imports: [HeroFormComponent, HeroListComponent],
  templateUrl: './hero-manager.component.html',
  styleUrl: './hero-manager.component.css',
})
export class HeroManagerComponent {
  constructor(private router: Router) {}
  createNewHero(): void {
    this.router.navigate(['/heroes/new']);
  }
}
