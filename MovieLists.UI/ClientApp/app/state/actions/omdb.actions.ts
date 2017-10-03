import { Action } from '@ngrx/store';
import { List } from "immutable";
import { MovieList } from "../../models/movie-list";
import { Movie } from "../../models/movie";

export const SEARCH_OMDB = '[OMDB] Search OMDB';
export const SEARCH_OMDB_SUCCESS = '[OMDB] Search OMDB Success';
export const SEARCH_OMDB_FAILURE = '[OMDB] Search OMDB Failure';

export class SearchOmdb implements Action {
    readonly type = SEARCH_OMDB;

    constructor(public payload: string) { }
}

export class SearchOmdbSuccess implements Action {
    readonly type = SEARCH_OMDB_SUCCESS;

    constructor(public payload: List<Movie>) { }
}

export class SearchOmdbFailure implements Action {
    readonly type = SEARCH_OMDB_FAILURE;

    constructor(public payload: any) { }
}

export const GET_SINGLE_MOVIE = '[OMDB] Get Single Movie';
export const GET_SINGLE_MOVIE_SUCCESS = '[OMDB] Get Single Movie Success';
export const GET_SINGLE_MOVIE_FAILURE = '[OMDB] Get Single Movie Failure';

export interface GetSingleMoviePayload{
    ImdbId: string;
    UserId: string;
}

export class GetSingleMovie implements Action {
    readonly type = GET_SINGLE_MOVIE;

    constructor(public payload: GetSingleMoviePayload) { }
}

export class GetSingleMovieSuccess implements Action {
    readonly type = GET_SINGLE_MOVIE_SUCCESS;

    constructor(public payload: Movie) { }
}

export class GetSingleMovieFailure implements Action {
    readonly type = GET_SINGLE_MOVIE_FAILURE;

    constructor(public payload: any) { }
}

export type Actions =
    | SearchOmdb
    | SearchOmdbSuccess
    | SearchOmdbFailure
    ////
    | GetSingleMovie
    | GetSingleMovieSuccess
    | GetSingleMovieFailure;