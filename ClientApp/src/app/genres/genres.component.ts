import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import MoviesService from '../movies.service';
import { movies } from '../movies';
import { AuthService } from '../auth.service';
import GenresService from '../genres.service';
import { genres } from '../genres';


@Component({
  selector: 'app-genres',
  templateUrl: './genres.component.html',
  styleUrls: ['./genres.component.css']
})
export class GenresComponent implements OnInit {

  public genres: genres[] = [];

  constructor(public authServic: AuthService, public genService: GenresService) { }

  ngOnInit() {
    this.genService.getAll().subscribe(data => {
      this.genres = data;
    });
  }

}
