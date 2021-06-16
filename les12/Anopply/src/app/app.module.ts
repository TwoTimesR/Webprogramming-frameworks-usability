import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LandingPageComponent } from './pages/landing-page/landing-page.component';
import { SiteLayoutComponent } from './pages/layout/site-layout/site-layout.component';
import { SiteFooterComponent } from './pages/layout/site-footer/site-footer.component';
import { SiteHeaderComponent } from './pages/layout/site-header/site-header.component';
import { routing } from './app.routing';
import { FormsModule } from '@angular/forms';
import { DetailsPageComponent } from './pages/details-page/details-page.component';

@NgModule({
  declarations: [
    AppComponent,
    LandingPageComponent,
    SiteLayoutComponent,
    SiteFooterComponent,
    SiteHeaderComponent,
    DetailsPageComponent,
  ],
  imports: [
    routing,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
  entryComponents: []
})
export class AppModule { }
