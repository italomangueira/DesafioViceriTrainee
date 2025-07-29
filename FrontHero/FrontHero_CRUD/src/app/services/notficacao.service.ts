import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class NotficacaoService {
  private heroUpdatedSource = new Subject<void>();
  heroUpdated$ = this.heroUpdatedSource.asObservable();

  notifyHeroUpdated() {
    this.heroUpdatedSource.next();
  }
}
