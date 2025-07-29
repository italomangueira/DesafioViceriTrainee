import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SuperPoder } from '../models/superpoder.model';

@Injectable({
  providedIn: 'root',
})
export class SuperpoderService {
  private apiUrl = 'https://localhost:7205/api/Superpoderes';

  constructor(private http: HttpClient) {}

  getSuperpoderes(): Observable<SuperPoder[]> {
    return this.http.get<SuperPoder[]>(this.apiUrl);
  }
}
