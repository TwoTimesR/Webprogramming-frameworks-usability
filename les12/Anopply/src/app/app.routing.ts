import { RouterModule, Routes } from '@angular/router';

import { SiteLayoutComponent } from './pages/layout/site-layout/site-layout.component';

import { LandingPageComponent } from './pages/landing-page/landing-page.component';
import { DetailsPageComponent } from './pages/details-page/details-page.component';

const appRoutes: Routes = [
  {
    path: '',
    component: SiteLayoutComponent,
    children: [
      { path: '', component: LandingPageComponent },
      { path: 'details/:heroId', component: DetailsPageComponent },
    ]
  },
  { path: '**', redirectTo: '' },
];

export const routing = RouterModule.forRoot(appRoutes);
