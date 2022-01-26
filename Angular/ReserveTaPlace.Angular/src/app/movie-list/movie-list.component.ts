import { IMovieList } from './../../models/movie/i-movie-list';
import { MovieService } from './../../service/movie.service';
import { Component, OnInit } from '@angular/core';
import { IMovie } from 'src/models/i-movie';

@Component({
  selector: 'app-movie-list',
  templateUrl: './movie-list.component.html',
  styleUrls: ['./movie-list.component.scss']
})
export class MovieListComponent implements OnInit {

  //movieList: IMovieList|undefined;
  public movieList: IMovie[]|undefined;
  public actor: string = "Aaaah";

  constructor(public movieService: MovieService) { }

  ngOnInit(): void {
    this.getMovies();
  }

  getMovies(): void{
    this.movieList = [];
    let iterations= 0;
    this.movieService.getMovies()
      .subscribe((movie: IMovie) =>{
        this.movieList?.push(movie);
        // for(let movie of movie.result)
        // {
        //     this.actor = movie.Title;
        //     console.log("Valeur de Title : "+ movie.Title);
        //     console.log("Valeur de Actors : "+ movie.Actors);
        //     console.log("Valeur de Director : "+ movie.Director);
        //     console.log(movie);
        //  }
        //this.movies.push(movie);
        //console.log(this.movies);
        // for(let movie of iMovieList.result)
        // {
        //   this.movies.push(movie);
        //   //console.log(( iterations++)+"- " +this.movies);
        // }
    });
    console.log(this.movieList);
  }
}