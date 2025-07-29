import { SuperPoder } from './superpoder.model';

export interface Hero {
  id?: number;
  nome: string;
  nomeHeroi: string;
  dataNascimento?: string | null;
  altura: number;
  peso: number;
  superpoderes?: SuperPoder[];
}
