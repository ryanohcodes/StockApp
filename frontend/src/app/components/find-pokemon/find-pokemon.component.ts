import { Component, OnInit ,Input, Output, EventEmitter} from '@angular/core';
import { Pokemon } from 'src/app/models/pokemon';
import { PokemonServiceService } from 'src/app/services/pokemon-service.service';

@Component({
  selector: 'app-find-pokemon',
  templateUrl: './find-pokemon.component.html',
  styleUrls: ['./find-pokemon.component.css']
})
export class FindPokemonComponent implements OnInit {
  @Input() mon? : Pokemon; 
  @Output() pokemonUpdated = new EventEmitter<Pokemon[]>();
  found : Pokemon[] = [];
  images : string[] = [];
  data: Pokemon = <Pokemon>{};
  constructor(private pokeService : PokemonServiceService) { }

  ngOnInit(): void {
  }
  findPokemon(mon : string) : void{
    this.pokeService
    .findPokemon(mon)
    .subscribe((response : any) =>{
      console.log(response)
      this.data.name = response.name;
      this.data.image = response.sprites.front_default;
      this.found.push(response)
      this.images.push(response.sprites.front_default);
    })
  }
  captureMon(mon : Pokemon) : void{
    console.log(this.data)
    this.found = [];
    this.images = [];
    this.pokeService
    .capturePokemon(this.data)
    .subscribe((pokemons: Pokemon[])=> {
      this.pokemonUpdated.emit(pokemons)
    })
    this.data.name = "";
    this.data.image = "";
  }
  removeMon(mon:Pokemon){
    this.pokeService.deletePokemon(mon)
    .subscribe((pokemons: Pokemon[]) => this.pokemonUpdated.emit(pokemons))
  }
}
