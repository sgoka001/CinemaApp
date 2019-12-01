import { Injectable, Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { movies } from './movies';
import { map } from "rxjs/operators";

@Injectable()
export default class MoviesService {
    public API = 'http://localhost:5001/api';
    public MOVIES_ENDPOINT = `${this.API}/Movies`;

    constructor(private httpClient: HttpClient) { }
    /*
    getAll(): Observable<Array<movies>> {
        return this.http.get<Array<movies>>(this.MOVIES_ENDPOINT);
    }
    */
    getAll(): Observable<movies[]> {
        return this.httpClient.get(`http://localhost:5001/api/Movies`).
            pipe(
                map((item: any) => item.map(p => <movies>
                    {
                        Name: p.Name,
                        //Name: p.name,
                        MovieID: p.MovieID,
                        Genre: p.Movie_Genre,
                        Released: p.Released,
                    })));
    }
}
