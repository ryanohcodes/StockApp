import { Component } from '@angular/core';
import { Pokemon } from './models/pokemon';
import { PokemonServiceService } from './services/pokemon-service.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  foundPokemon? : Pokemon;
  box : Pokemon[] = [];

  constructor (private pokeService: PokemonServiceService){

  }

  ngOnInit(): void{
    this.pokeService
    .getPokemon()
    .subscribe((result: Pokemon[])=> (this.box = result));
  }

  findPokemon(){
    this.foundPokemon = new Pokemon();
  }
  updatePokemonList(pokemon: Pokemon[]){
    this.box = pokemon;
  }
  
}
