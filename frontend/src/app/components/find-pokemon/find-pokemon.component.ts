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
    .findPokemon(mon.toLowerCase())
    .subscribe((response : any) =>{
      console.log(response)
      this.clean();
      this.display(response);
    })
  }
  clean() : void{
    if(this.found.length > 0){
      this.found = [];
      this.images = [];
    }
  }
  display(response : any): void{
      this.data.name = response.name[0].toUpperCase() + response.name.slice(1);
      this.data.image = response.sprites.front_default;
      this.data.weight = response.weight;
      this.data.height = response.height/10;
      this.data.dexid = response.id;
      this.found.push(response);
      this.images.push(response.sprites.front_default);
  }
  getRandomMon() : void{
    this.clean();
    let numberOfMons = 251;
    this.pokeService.findPokemon(Math.floor(Math.random() * numberOfMons))
    .subscribe((response: any) =>{
      this.display(response);
    })
  }
  captureMon(mon : Pokemon) : void{
    console.log(this.data);
    console.log(mon);
    this.clean();
    this.pokeService
    .capturePokemon(this.data)
    .subscribe((pokemons: Pokemon[])=> {
      this.pokemonUpdated.emit(pokemons)
    })
    this.data.name = "";
    this.data.image = "";
    this.data.weight = 0;
      this.data.height = 0;
      this.data.dexid = 0;
  }
  
    
    
    
  removeMon(mon:Pokemon){
    this.pokeService.deletePokemon(mon)
    .subscribe((pokemons: Pokemon[]) => this.pokemonUpdated.emit(pokemons))
  }
}
