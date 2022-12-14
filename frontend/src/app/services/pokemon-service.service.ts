import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Pokemon } from '../models/pokemon';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PokemonServiceService {

  constructor(private http: HttpClient) { 

  }
  
  public findPokemon(pokemon: string | number){
    return this.http.get(`${environment.pokeUrl}/${pokemon}`)
  }

  public getPokemon() : Observable<Pokemon[]>{
    return this.http.get<Pokemon[]>(`${environment.backendUrl}`)
  }
  public deletePokemon(mon: Pokemon) : Observable<Pokemon[]>{
    return this.http.delete<Pokemon[]>(
      `${environment.backendUrl}/${mon.id}`
    )
  }
  
  public capturePokemon(mon: Pokemon) : Observable<Pokemon[]>{
    return this.http.post<Pokemon[]>(
      `${environment.backendUrl}`,mon)
  }
  public sortPokemonByWeight(): Observable<Pokemon[]>{
    return this.http.get<Pokemon[]>(`${environment.backendUrl}/weight`)
  }
  public sortPokemonByHeight(num : Number): Observable<Pokemon[]>{
    return this.http.get<Pokemon[]>(`${environment.backendUrl}/heights/heights`)
  }
  public filterPokeMonByWeight(num: Number): Observable<Pokemon[]>{
    return this.http.get<Pokemon[]>(`${environment.backendUrl}/weights/${num}`)
  }
}