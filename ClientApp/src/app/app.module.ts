import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import MoviesService from './movies.service';
import { MoviesComponent } from './movies/movies.component';
import { HttpModule } from "@angular/http";

import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { AngularmaterialModule } from './material/angularmaterial/angularmaterial.module';  
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import GenresService from './genres.service';
import { GenresComponent } from './genres/genres.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    MoviesComponent,
    GenresComponent
  ],
  imports: [
      BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
      BrowserAnimationsModule,
      HttpClientModule, Ng2SearchPipeModule,  
      HttpModule,
      FormsModule,
      AngularmaterialModule, 
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
        { path: 'fetch-data', component: FetchDataComponent },
      { path: 'movies', component: MoviesComponent },
      { path: 'genres', component: GenresComponent }
    ])
  ],
  providers: [MoviesService, GenresService],
  bootstrap: [AppComponent]
})
export class AppModule { }
