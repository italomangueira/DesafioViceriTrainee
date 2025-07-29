import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { HeroService } from '../../services/hero.service';
import { SuperpoderService } from '../../services/superpoder.service';
import { Hero } from '../../models/heroi.model';
import { SuperPoder } from '../../models/superpoder.model';
import { NgFor, NgIf } from '@angular/common';
import { NotficacaoService } from '../../services/notficacao.service';

@Component({
  selector: 'app-hero-form',
  imports: [NgFor, NgIf, ReactiveFormsModule],
  templateUrl: './hero-form.component.html',
  styleUrls: ['./hero-form.component.css'],
})
export class HeroFormComponent implements OnInit {
  heroForm!: FormGroup;
  superpoderes: SuperPoder[] = [];
  currentHeroId: number | null = null;

  constructor(
    private fb: FormBuilder,
    private heroService: HeroService,
    private superpoderService: SuperpoderService,
    private route: ActivatedRoute,
    private router: Router,
    private notificationService: NotficacaoService
  ) {}

  ngOnInit(): void {
    this.initializeForm();
    this.loadSuperpoderes();

    this.route.paramMap.subscribe((params) => {
      const idParam = params.get('id');
      if (idParam) {
        this.currentHeroId = +idParam;
        this.loadHeroById(this.currentHeroId);
      } else {
        this.currentHeroId = null;
        this.heroForm.reset();
        this.heroForm.get('superpoderes')?.setValue([]);
      }
    });
  }

  initializeForm(): void {
    this.heroForm = this.fb.group({
      id: [null],
      nome: ['', Validators.required],
      nomeHeroi: ['', Validators.required],
      dataNascimento: [null],
      altura: [null, [Validators.required, Validators.min(0.01)]],
      peso: [null, [Validators.required, Validators.min(0.01)]],
      superpoderes: [[]],
    });
  }

  loadSuperpoderes(): void {
    this.superpoderService.getSuperpoderes().subscribe({
      next: (data: SuperPoder[]) => {
        this.superpoderes = data;
      },
      error: (err) => {
        console.error('Erro ao carregar superpoderes:', err);
        alert('Não foi possível carregar a lista de superpoderes.');
      },
    });
  }

  loadHeroById(id: number): void {
    this.heroService.getHeroById(id).subscribe({
      next: (hero: Hero) => {
        let formattedDataNascimento: string | null = null;
        if (hero.dataNascimento) {
          const dateValue = new Date(hero.dataNascimento);
          if (!isNaN(dateValue.getTime())) {
            formattedDataNascimento = dateValue.toISOString().split('T')[0];
          }
        }

        const selectedSuperpoderIds = hero.superpoderes?.map((s) => s.id) || [];

        this.heroForm.patchValue({
          ...hero,
          superpoderes: selectedSuperpoderIds,
        });
      },
      error: (err) => {
        console.error('Erro ao carregar herói:', err);
        alert(
          'Erro ao carregar herói. Ele pode não existir ou o servidor está indisponível.'
        );
        this.router.navigate(['/heroes']);
      },
    });
  }

  compareFn(valor1: any, valor2: any): boolean {
    return valor1 === valor2;
  }

  onSubmit(): void {
    if (this.heroForm.valid) {
      const heroData: any = { ...this.heroForm.value };

      if (heroData.dataNascimento) {
        try {
          const date = new Date(heroData.dataNascimento + 'T00:00:00');
          if (isNaN(date.getTime())) {
            heroData.dataNascimento = null;
          } else {
            heroData.dataNascimento = date.toISOString();
          }
        } catch (e) {
          console.error('Erro ao converter data de nascimento:', e);
          heroData.dataNascimento = null;
        }
      } else {
        heroData.dataNascimento = null;
      }

      heroData.superpoderesIds = heroData.superpoderes;
      delete heroData.superpoderes;

      if (this.currentHeroId) {
        // atualização de heroi
        this.heroService.updateHero(this.currentHeroId, heroData).subscribe({
          next: () => {
            alert('Herói atualizado com sucesso!');
            this.notificationService.notifyHeroUpdated();
            this.router.navigate(['/heroes']);
          },
          error: (err) => {
            console.error('Erro ao atualizar herói:', err);
            alert(
              'Falha ao atualizar herói. Verifique sua conexão e tente novamente.'
            );
          },
        });
      } else {
        //  criação de heroi
        this.heroService.createHero(heroData).subscribe({
          next: () => {
            alert('Herói criado com sucesso!');
            this.notificationService.notifyHeroUpdated();
            this.router.navigate(['/heroes']);
          },
          error: (err) => {
            console.error('Erro ao criar herói:', err);
            alert(
              'Falha ao criar herói. Verifique os dados e tente novamente.'
            );
          },
        });
      }
    } else {
      alert('Por favor, preencha todos os campos obrigatórios corretamente.');
      this.heroForm.markAllAsTouched();
    }
  }

  deleteHero(): void {
    if (
      this.currentHeroId &&
      confirm('Tem certeza que deseja EXCLUIR este herói?')
    ) {
      this.heroService.deleteHero(this.currentHeroId).subscribe({
        next: () => {
          alert('Herói excluído com sucesso!');
          this.router.navigate(['/heroes']);
        },
        error: (err) => {
          console.error('Erro ao excluir herói:', err);
          alert('Falha ao excluir herói. Tente novamente.');
        },
      });
    }
  }
}
