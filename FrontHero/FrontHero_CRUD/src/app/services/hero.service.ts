import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Hero } from '../models/heroi.model';

@Injectable({
  providedIn: 'root',
})
export class HeroService {
  private apiUrl = 'https://localhost:7205/api/Herois';

  constructor(private http: HttpClient) {}

  getHeroes(): Observable<Hero[]> {
    return this.http.get<Hero[]>(this.apiUrl);
  }

  getHeroById(id: number): Observable<Hero> {
    return this.http.get<Hero>(`${this.apiUrl}/${id}`);
  }

  createHero(hero: Hero): Observable<Hero> {
    const { id, ...heroWithoutId } = hero;
    return this.http.post<Hero>(this.apiUrl, heroWithoutId);
  }

  updateHero(id: number, hero: Hero): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, hero);
  }

  deleteHero(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
