import { IMovieList } from './../../models/movie/i-movie-list';
import { MovieService } from './../../service/movie.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-movie-list',
  templateUrl: './movie-list.component.html',
  styleUrls: ['./movie-list.component.scss']
})
export class MovieListComponent implements OnInit {

  iMovieList: IMovieList|undefined;


  constructor(public movieService: MovieService) { }

  ngOnInit(): void {
  }

  displayMovies(){
    this.movieService.getMovies();
  }

}
