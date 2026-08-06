import { Routes } from '@angular/router';
import { MainLayoutComponent } from './core/layout/main-layout/main-layout.component';

export const routes: Routes = [
  {
    path: '',
    component: MainLayoutComponent,
    children: [
      { path: '', redirectTo: 'country', pathMatch: 'full' },
      {
        path: 'test',
        title: 'Test Operations',
        loadComponent: () =>
          import('./Feature/TestModule/view-test/view-test.component').then(
            (m) => m.ViewTestComponent
          ),
      },

      // ---- Country ----
      {
        path: 'country',
        title: 'Countries',
        loadComponent: () =>
          import('./Feature/CountryModule/view-country/view-country.component').then(
            (m) => m.ViewCountryComponent
          ),
      },
      {
        path: 'country/new',
        title: 'New Country',
        data: { mode: 'create' },
        loadComponent: () =>
          import('./Feature/CountryModule/country-form/country-form.component').then(
            (m) => m.CountryFormComponent
          ),
      },
      {
        path: 'country/:id/edit',
        title: 'Edit Country',
        data: { mode: 'edit' },
        loadComponent: () =>
          import('./Feature/CountryModule/country-form/country-form.component').then(
            (m) => m.CountryFormComponent
          ),
      },

      // ---- City ----
      {
        path: 'city',
        title: 'Cities',
        loadComponent: () =>
          import('./Feature/CityModule/view-city/view-city.component').then(
            (m) => m.ViewCityComponent
          ),
      },
      {
        path: 'city/new',
        title: 'New City',
        data: { mode: 'create' },
        loadComponent: () =>
          import('./Feature/CityModule/city-form/city-form.component').then(
            (m) => m.CityFormComponent
          ),
      },
      {
        path: 'city/:id/edit',
        title: 'Edit City',
        data: { mode: 'edit' },
        loadComponent: () =>
          import('./Feature/CityModule/city-form/city-form.component').then(
            (m) => m.CityFormComponent
          ),
      },

      { path: '**', redirectTo: 'country' },
    ],
  },
];
