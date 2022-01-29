import { MovieService } from './../../service/movie.service';
import { Component, OnInit } from '@angular/core';
import { IMovie } from 'src/models/movie/i-movie';

@Component({
  selector: 'app-movie-list',
  templateUrl: './movie-list.component.html',
  styleUrls: ['./movie-list.component.scss']
})
export class MovieListComponent implements OnInit {

  public movieArray: IMovie[]|undefined;

  constructor(public movieService: MovieService) { }

  ngOnInit(): void {
    this.getMovies();
  }

  getMovies(): void{
    this.movieService.getMovies()
      .subscribe((movieArray: IMovie[]) =>{
        this.movieArray = movieArray;
        console.log(this.movieArray);
    });
  }
}