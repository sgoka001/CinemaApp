import { Component, Inject, OnInit, ViewChild  } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import MoviesService from '../movies.service';
import { movies } from '../movies';

import { MatTableDataSource, MatSort } from '@angular/material';  
import {
    trigger,
    state,
    style,
    animate,
    transition
} from '@angular/animations';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.css']
})
    
export class MoviesComponent {

    public moviesList: movies[] = [];

    public dataSource: MatTableDataSource<movies>;
    displayedColumns: string[] = ['movieId', 'name', 'released', 'movie_Genre'];
    @ViewChild(MatSort, { read: true, static: false }) sort: MatSort; 
    constructor(private apiService: MoviesService, ) {      
    }       

    ngOnInit() {
        this.apiService.getAll().subscribe(data => {
            this.moviesList = data;
        });
        this.apiService.getAllSearchable().subscribe(data => {
            this.dataSource = new MatTableDataSource(data);
            this.dataSource.sort = this.sort;
        });       
    }

    applyFilter(filterValue: string) {
        this.dataSource.filter = filterValue.trim().toLowerCase();
    }
    
}

    /*
export class MoviesComponent {
    public moviesList: IMovies;

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        http.get<IMovies>(baseUrl + 'api/movies').subscribe(result => {
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
*/
