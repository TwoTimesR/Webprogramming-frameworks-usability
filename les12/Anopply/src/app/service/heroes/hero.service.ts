import { Injectable } from '@angular/core';
import { Hero } from 'src/app/model/heroes/hero.model';

@Injectable({
  providedIn: 'root'
})
export class HeroService {

  private heroes = [] as Array<Hero>;
  constructor() { }

  getApiCall() {
    console.error("Ik ben een api call");
  }

  generateHeroes() {
    this.heroes.push(new Hero(1, "Batman", 30, "DC Superheld"));
    this.heroes.push(new Hero(2, "Superman", 20, "DC Superheld"));
    this.heroes.push(new Hero(3, "Flash", 10, "DC Superheld"));
  }

  getHeroes() {
    return this.heroes;
  }

  getHeroById(id): Hero {
    let selectedHero
    this.heroes.forEach(hero => {
      if (hero.id == id) {
        selectedHero = hero;
      }
    });
    return selectedHero;
  }

  createHero(name, age, description) {
    let id = this.heroes.length + 2;
    let newHero = new Hero(id, name, age, description);
    this.heroes.push(newHero);
    this.getHeroes();
  }

}
