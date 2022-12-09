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
  preserve : Number;

  constructor (private pokeService: PokemonServiceService){
    this.preserve = 0;
  }

  ngOnInit(): void{
    this.pokeService
    .getPokemon()
    .subscribe((result: Pokemon[])=> (this.box = result));
  }
  getMon(){
    this.pokeService
    .getPokemon()
    .subscribe((result: Pokemon[])=> (this.box = result));
  }
  findPokemon(){
    this.foundPokemon = new Pokemon();
  }
  updatePokemonList(pokemon: Pokemon[]){
    if(this.preserve === 0)this.box = pokemon;
    else if(this.preserve === 1) this.sortByWeight();
    else if (this.preserve === 2) this.sortByHeight();
    else this.box = pokemon;
  }
  removeMon(mon:Pokemon){
    this.pokeService.deletePokemon(mon)
    .subscribe((result: Pokemon[])=> {
      this.updatePokemonList(result);
    })
  }
  sortByWeight(): void{
    this.preserve = 1;
    this.pokeService.sortPokemonByWeight()
    .subscribe((result: Pokemon[])=> (this.box = result));
  }
  sortByHeight(): void{
    this.preserve = 2;
    this.pokeService.sortPokemonByHeight(0)
    .subscribe((result: Pokemon[])=> (this.box = result));
  }
  
}
