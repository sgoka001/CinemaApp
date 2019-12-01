import { Component, OnInit } from '@angular/core';
import MoviesService from './movies.service';
import { movies } from './movies';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
    title = 'MovieApp';
}
