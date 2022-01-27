import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IMovie } from 'src/models/movie/i-movie';

@Injectable({
  providedIn: 'root'
})
export class MovieService {

  baseUrl: string = 'https://localhost:7091/api/Movie'

  constructor(private httpClient: HttpClient) { }

  getMovies(): Observable<IMovie[]> {
    return this.httpClient.get<IMovie[]>(this.baseUrl);
  }
}
