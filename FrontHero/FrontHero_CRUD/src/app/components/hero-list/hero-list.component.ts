import { Component, OnDestroy, OnInit } from '@angular/core';
import { DatePipe, NgFor, NgIf } from '@angular/common';
import { HeroService } from '../../services/hero.service';
import { Hero } from '../../models/heroi.model';
import { Router, RouterLink } from '@angular/router';
import { Subscription } from 'rxjs';
import { NotficacaoService } from '../../services/notficacao.service';

@Component({
  selector: 'app-hero-list',
  imports: [NgFor, NgIf, DatePipe, RouterLink],
  templateUrl: './hero-list.component.html',
  styleUrls: ['./hero-list.component.css'],
})
export class HeroListComponent implements OnInit, OnDestroy {
  herois: Hero[] = [];

  private heroUpdateSubscription!: Subscription;

  constructor(
    private heroService: HeroService,
    private router: Router,
    private notificationService: NotficacaoService
  ) {}

  ngOnInit(): void {
    this.loadHeroes();
    this.heroUpdateSubscription =
      this.notificationService.heroUpdated$.subscribe(() => {
        this.loadHeroes();
      });
  }

  ngOnDestroy(): void {
    if (this.heroUpdateSubscription) {
      this.heroUpdateSubscription.unsubscribe();
    }
  }

  loadHeroes(): void {
    this.heroService.getHeroes().subscribe({
      next: (data: Hero[]) => {
        this.herois = data;
      },
      error: (err) => {
        console.error('Erro ao carregar heróis:', err);
        alert(
          'Não foi possível carregar a lista de heróis. Tente novamente mais tarde.'
        );
      },
    });
  }

  editHero(id?: number): void {
    if (id) {
      this.router.navigate(['/heroes/edit', id]);
    }
  }

  deleteHero(id: number | undefined): void {
    if (id && confirm('Tem certeza que deseja excluir este herói?')) {
      this.heroService.deleteHero(id).subscribe({
        next: () => {
          alert('Herói excluído com sucesso!');
          this.loadHeroes();
        },
        error: (err) => {
          console.error('Erro ao excluir herói:', err);
          alert(
            'Falha ao excluir herói. Verifique se ele não está relacionado a outras entidades.'
          );
        },
      });
    } else if (id === undefined) {
      console.warn('Tentativa de excluir herói sem ID.');
      alert('Não foi possível excluir o herói: ID não encontrado.');
    }
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

    const dataDeNascimento = new Date(dataNascimento);

    if (isNaN(dataDeNascimento.getTime())) {
      return 'Data inválida';
    }

    const hoje = new Date();
    let idade = hoje.getFullYear() - dataDeNascimento.getFullYear();
    const mes = hoje.getMonth() - dataDeNascimento.getMonth();

    if (mes < 0 || (mes === 0 && hoje.getDate() < dataDeNascimento.getDate())) {
      idade--;
    }

    return idade;
  }
}
