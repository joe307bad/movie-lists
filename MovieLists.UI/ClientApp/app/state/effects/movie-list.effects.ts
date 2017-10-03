import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/exhaustMap';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/take';
import { Action } from '@ngrx/store';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Actions, Effect, toPayload } from '@ngrx/effects';
import { of } from 'rxjs/observable/of';
import { defer } from 'rxjs/observable/defer';

import * as movieListActions from '../actions/movie-list.actions';
import { Observable } from "rxjs/Observable";
import { List } from "immutable";
import { MovieListService } from "../../services/movie-list.service";


@Injectable()
export class MovieListEffects {
    @Effect()
    createMovieList$: Observable<Action> = this.actions$.ofType(movieListActions.CREATE_MOVIE_LIST)
        .map(toPayload)
        .switchMap((movieList) => this
            .movieListService
            .CreateMovieList(movieList)
            .map((movieList) => new movieListActions.CreateMovieListSuccess(movieList))
            .catch((error: any) => of(new movieListActions.CreateMovieListFailure(error))));

    constructor(
        private actions$: Actions,
        private router: Router,
        private movieListService: MovieListService
    ) { }
}