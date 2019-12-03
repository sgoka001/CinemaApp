import { Injectable, Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { movies } from './movies';
import { map } from "rxjs/operators";

@Injectable()
export default class MoviesService {
    public API = 'https://localhost:5001/api';
    public MOVIES_ENDPOINT = `${this.API}/Movies`;

    constructor(private httpClient: HttpClient, private http: HttpClient) { }
    
    getAllSearchable(): Observable<movies[]> {
        return this.http.get<movies[]>(this.MOVIES_ENDPOINT);
    }
    
    getAll(): Observable<movies[]> {
        return this.httpClient.get<movies[]>(this.MOVIES_ENDPOINT).
            pipe(
                map((item: any) => item.map(p => <movies>
                    {
                        Name: p.name,
                        MovieID: p.movieId,
                        Genre: p.movie_Genre,
                        Released: p.released,
                    })));
    }
}
