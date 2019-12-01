import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import MoviesService from '../movies.service';
import { movies } from '../movies';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.css']
})
    /*
export class MoviesComponent {

    moviesArr: movies[];

    constructor(private apiService: MoviesService) {
    }

    ngOnInit() {
        this.apiService.getAll().subscribe(data => {
            this.moviesArr = data;
        });
    }
}
*/

export class MoviesComponent {
    public moviesList: IMovies[];

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        http.get<IMovies[]>(baseUrl + 'api/movies').subscribe(result => {
            this.moviesList = result;
        }, error => console.error(error));
    }
    ngOnInit() {

    }
}

interface IMovies {
    movieId: number;
    name: string;
    released: number;
    movie_Genre: string;
}

