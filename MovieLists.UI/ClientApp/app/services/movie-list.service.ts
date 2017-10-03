import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";
import { Http } from '@angular/http';
import { List } from "immutable";
import { environment } from "../environments/environment";
import { MovieList } from "../models/movie-list";
import { Movie } from "../models/movie";

@Injectable()
export class MovieListService {
    constructor(private http: Http) { }

    CreateMovieList(movieList: MovieList): Observable<MovieList> {
        return this.http.post(environment.movieListsApi, movieList).map((movieList) => movieList.json());
    }

    GetAllMovieLists(): Observable<List<MovieList>> {
        return this.http.get(environment.movieListsApi).map((movieLists) => movieLists.json());
    }

    GetSingleMovieList(id: string): Observable<MovieList> {
        return this.http.get(environment.movieListsApi + id).map((movieList) => movieList.json());
    }

    DeleteMovieList(id: string): Observable<MovieList> {
        return this.http.delete(environment.movieListsApi + id).map((movieList) => movieList.json());
    }

    UpdateMovieList(id: string, movieList: MovieList): Observable<MovieList> {
        return this.http.put(environment.movieListsApi + id, movieList).map((movieList) => movieList.json());
    }

    AddMovieToList(id: string, movie: Movie): Observable<MovieList> {
        return this.http.put(environment.movieListsApi + "AddMovie/" + id, movie).map((movieList) => movieList.json());
    }

    DeleteMovieFromList(id: string, movie: Movie): Observable<MovieList> {
        return this.http.put(environment.movieListsApi + "RemoveMovie/" + id, movie).map((movieList) => movieList.json());
    }
    
}