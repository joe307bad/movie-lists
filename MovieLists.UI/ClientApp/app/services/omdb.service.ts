import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";
import { Http } from '@angular/http';
import { List } from "immutable";
import { environment } from "../environments/environment";
import { MovieList } from "../models/movie-list";
import { Movie } from "../models/movie";

@Injectable()
export class OmdbService {
    constructor(private http: Http) { }

    Search(query: string): Observable<List<Movie>> {
        return this.http.get(environment.omdbApi + "Search?query=" + query).map((movies) => movies.json());
    }

    GetSingleMovie(imdbId: string, userId: string): Observable<Movie> {
        return this.http.get(environment.omdbApi + "GetSingle/?movieImdbId=" + imdbId + "&userId=" + userId).map((movie) => movie.json());
    }

}