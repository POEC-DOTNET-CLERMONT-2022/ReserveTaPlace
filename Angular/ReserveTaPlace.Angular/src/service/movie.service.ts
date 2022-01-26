import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IMovieList } from 'src/models/movie/i-movie-list';

@Injectable({
  providedIn: 'root'
})
export class MovieService {

baseUrl: string = 'https://localhost:7091/api/Movie'

  constructor(private httpClient: HttpClient) { }

  getMovies(url: string): Observable<IMovieList> {
    return this.httpClient.get<IMovieList>(url);
  }
}
