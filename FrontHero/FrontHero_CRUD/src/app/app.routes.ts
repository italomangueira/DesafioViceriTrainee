import { Routes } from '@angular/router';
import { HeroFormComponent } from './components/hero-form/hero-form.component';
import { HeroListComponent } from './components/hero-list/hero-list.component';
import { HeroManagerComponent } from './components/hero-manager/hero-manager.component';
import { HeroDetailComponent } from './components/hero-detail/hero-detail.component';

export const routes: Routes = [
  { path: 'heroes', component: HeroManagerComponent }, // Rota para a lista de heróis
  { path: 'heroes/new', component: HeroFormComponent }, // Rota para criar novo herói
  { path: 'heroes/edit/:id', component: HeroFormComponent },
  { path: 'heroes/:id', component: HeroDetailComponent }, // Rota para editar herói por ID
  { path: '', redirectTo: '/heroes', pathMatch: 'full' }, // Redireciona a raiz para a lista
  // { path: '**', component: NotFoundComponent } // Opcional: para rotas não encontradas
];
