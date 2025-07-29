import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HeroService } from '../../services/hero.service';
import { Hero } from '../../models/heroi.model';
import { NgIf, NgFor } from '@angular/common';

@Component({
  selector: 'app-hero-detail',
  imports: [NgIf, NgFor],
  templateUrl: './hero-detail.component.html',
  styleUrls: ['./hero-detail.component.css'],
})
export class HeroDetailComponent implements OnInit {
  hero: Hero | undefined;
  isLoading: boolean = true;
  errorMessage: string = '';

  constructor(
    private route: ActivatedRoute,
    private heroService: HeroService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe((params) => {
      const heroId = params.get('id');
      if (heroId) {
        this.loadHeroDetails(+heroId);
      } else {
        this.errorMessage = 'ID do herói não fornecido.';
        this.isLoading = false;
      }
    });
  }

  loadHeroDetails(id: number): void {
    this.isLoading = true;
    this.heroService.getHeroById(id).subscribe({
      next: (data: Hero) => {
        this.hero = data;
        this.isLoading = false;
        console.log('Detalhes do herói carregados:', this.hero);
      },
      error: (err) => {
        console.error('Erro ao carregar detalhes do herói:', err);
        this.errorMessage = 'Herói não encontrado ou erro ao carregar dados.';
        this.isLoading = false;
      },
    });
  }

  getSuperpoderesDisplay(hero: Hero): string {
    if (hero.superpoderes && hero.superpoderes.length > 0) {
      return hero.superpoderes.map((s) => s.superPoder).join(', ');
    }
    return 'Nenhum';
  }

  getAge(dataNascimento: string | null | undefined): number | string {
    if (!dataNascimento) {
      return 'Não informado';
    }

    const birthDate = new Date(dataNascimento);
    if (isNaN(birthDate.getTime())) {
      return 'Data inválida';
    }

    const today = new Date();
    let age = today.getFullYear() - birthDate.getFullYear();
    const m = today.getMonth() - birthDate.getMonth();

    if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
      age--;
    }

    return age;
  }

  goBack(): void {
    this.router.navigate(['/heroes']);
  }

  editHero(id?: number): void {
    if (id) {
      this.router.navigate(['/heroes/edit', id]);
    }
  }
}
