import { Component, OnInit } from '@angular/core';
import { HeroService } from 'src/app/service/heroes/hero.service';

@Component({
  selector: 'app-landing-page',
  templateUrl: './landing-page.component.html',
  styleUrls: ['./landing-page.component.scss']
})
export class LandingPageComponent implements OnInit {
  private heroes = [];
  private name: string;
  private age: number;
  private description: string;
  private empty: boolean = false;
  private easteregg: boolean = false;
  private attempt: number = 0;

  constructor(private heroService: HeroService) { }

  ngOnInit() {
    this.heroService.getApiCall();
    this.heroService.generateHeroes();
    this.heroes = this.heroService.getHeroes();
    this.heroes.forEach(hero => {
      console.warn(hero.name, hero.age);
    });
  }

  createNewHero() {
    if ((this.name == undefined && this.age == undefined) || (this.name == "" && this.age == null)) {
      this.attempt++;
      if (this.attempt == 3) {
        this.easteregg = true;
      }
      this.empty = true;
    } else {
      this.heroService.createHero(this.name, this.age, this.description);
      this.empty = false
      this.attempt = 0;
    }

  }



}
