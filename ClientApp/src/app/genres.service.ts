import { Injectable, Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { genres } from './genres';
import { map } from "rxjs/operators";

@Injectable()
export default class GenresService {
  public API = 'https://localhost:5001/api';
  public VM_ENDPOINT = `${this.API}/GenreMovieVM`;
  public GENRE_TYPE = `${this.API}/GenreMovieVM`;

  constructor(private httpClient: HttpClient, private http: HttpClient) { }

  getAll(): Observable<genres[]> {
    return this.http.get<genres[]>(this.GENRE_TYPE);
  }
  scifi() {
    this.GENRE_TYPE = `${this.API}/GenreMovieVM/Sci-Fi`;
  }
  comedy() {
    this.GENRE_TYPE = `${this.API}/GenreMovieVM/Comedy`;
  }
  sad() {
    this.GENRE_TYPE = `${this.API}/GenreMovieVM/Sad`;
  }
}
