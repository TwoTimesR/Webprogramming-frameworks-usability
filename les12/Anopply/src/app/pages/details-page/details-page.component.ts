import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Hero } from 'src/app/model/heroes/hero.model';
import { HeroService } from 'src/app/service/heroes/hero.service';

@Component({
  selector: 'app-details-page',
  templateUrl: './details-page.component.html',
  styleUrls: ['./details-page.component.scss']
})
export class DetailsPageComponent implements OnInit {

  private heroId: number;
  private hero = [];

  constructor(public heroService: HeroService, private route: ActivatedRoute,) { }

  ngOnInit() {
    this.route.params.subscribe((params) => {
      this.heroId = params['heroId'];
    })

    this.hero.push(this.heroService.getHeroById(this.heroId));
  }
}
