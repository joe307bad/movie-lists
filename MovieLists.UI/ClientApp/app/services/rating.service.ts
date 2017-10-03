import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";
import { Http } from '@angular/http';
import { List } from "immutable";
import { environment } from "../environments/environment";
import { MovieList } from "../models/movie-list";
import { Movie } from "../models/movie";
import { Rating } from "../models/rating";

@Injectable()
export class RatingService {
    constructor(private http: Http) { }

    CreateRating(rating: Rating): Observable<Rating>{
        return this.http.post(environment.ratingsApi, rating).map((rating) => rating.json());
    }

    UpdateRating(id: string, rating: Rating): Observable<Rating> {
        return this.http.put(environment.ratingsApi + id, rating).map((rating) => rating.json());
    }

}