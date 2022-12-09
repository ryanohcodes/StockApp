import { Component, OnInit,Input,Output,EventEmitter } from '@angular/core';
import { PokemonServiceService } from 'src/app/services/pokemon-service.service';
import { Pokemon } from 'src/app/models/pokemon';


@Component({
  selector: 'app-weight-filter',
  templateUrl: './weight-filter.component.html',
  styleUrls: ['./weight-filter.component.css']
})
export class WeightFilterComponent implements OnInit {
  @Input() num? : Number | any; 
  @Output() pokemonUpdated = new EventEmitter<Pokemon[]>();
  box : Pokemon[] = [];

  constructor(private pokeService : PokemonServiceService) { }

  ngOnInit(): void {
  }
  filterMonByWeight(num : Number): void{
    this.pokeService.filterPokeMonByWeight(num)
    .subscribe((pokemons: Pokemon[]) => this.pokemonUpdated.emit(pokemons))
  }
}
