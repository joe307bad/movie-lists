import { Action } from '@ngrx/store';
import { List } from "immutable";
import { MovieList } from "../../models/movie-list";
import { Movie } from "../../models/movie";

export const CREATE_MOVIE_LIST = '[MovieList] Create Movie List';
export const CREATE_MOVIE_LIST_SUCCESS = '[MovieList] Create Movie List Success';
export const CREATE_MOVIE_LIST_FAILURE = '[MovieList] Create Movie List Failure';

export class CreateMovieList implements Action {
    readonly type = CREATE_MOVIE_LIST;

    constructor(public payload: MovieList) { }
}

export class CreateMovieListSuccess implements Action {
    readonly type = CREATE_MOVIE_LIST_SUCCESS;

    constructor(public payload: MovieList) { }
}

export class CreateMovieListFailure implements Action {
    readonly type = CREATE_MOVIE_LIST_FAILURE;

    constructor(public payload: any) { }
}

export const GET_ALL_MOVIE_LISTS = '[MovieList] Get All Movie Lists';
export const GET_ALL_MOVIE_LISTS_SUCCESS = '[MovieList] Get All Movie Lists Success';
export const GET_ALL_MOVIE_LISTS_FAILURE = '[MovieList] Get All Movie Lists Failure';

export class GetAllMovieLists implements Action {
    readonly type = GET_ALL_MOVIE_LISTS;

    constructor() { }
}

export class GetAllMovieListsSuccess implements Action {
    readonly type = GET_ALL_MOVIE_LISTS_SUCCESS;

    constructor(public payload: List<MovieList>) { }
}

export class GetAllMovieListsFailure implements Action {
    readonly type = GET_ALL_MOVIE_LISTS_FAILURE;

    constructor(public payload: any) { }
}

export const GET_SINGLE_MOVIE_LIST = '[MovieList] Get Single Movie List';
export const GET_SINGLE_MOVIE_LIST_SUCCESS = '[MovieList] Get Single Movie List Success';
export const GET_SINGLE_MOVIE_LIST_FAILURE = '[MovieList] Get Single Movie List Failure';

export class GetSingleMovieList implements Action {
    readonly type = GET_SINGLE_MOVIE_LIST;

    constructor(public payloa: string) { }
}

export class GetSingleMovieListSuccess implements Action {
    readonly type = GET_SINGLE_MOVIE_LIST_SUCCESS;

    constructor(public payload: MovieList) { }
}

export class GetSingleMovieListFailure implements Action {
    readonly type = GET_SINGLE_MOVIE_LIST_FAILURE;

    constructor(public payload: any) { }
}

export const DELETE_MOVIE_LIST = '[MovieList] Delete Movie List';
export const DELETE_MOVIE_LIST_SUCCESS = '[MovieList] Delete Movie List Success';
export const DELETE_MOVIE_LIST_FAILURE = '[MovieList] Delete Movie List Failure';

export class DeleteMovieList implements Action {
    readonly type = DELETE_MOVIE_LIST;

    constructor(public payload: string) { }
}

export class DeleteMovieListSuccess implements Action {
    readonly type = DELETE_MOVIE_LIST_SUCCESS;

    constructor(public payload: MovieList) { }
}

export class DeleteMovieListFailure implements Action {
    readonly type = DELETE_MOVIE_LIST_FAILURE;

    constructor(public payload: any) { }
}

export const UPDATE_MOVIE_LIST = '[MovieList] Update Movie List';
export const UPDATE_MOVIE_LIST_SUCCESS = '[MovieList] Update Movie List Success';
export const UPDATE_MOVIE_LIST_FAILURE = '[MovieList] Update Movie List Failure';

export class UpdateMovieList implements Action {
    readonly type = UPDATE_MOVIE_LIST;

    constructor(public payload: MovieList) { }
}

export class UpdateMovieListSuccess implements Action {
    readonly type = UPDATE_MOVIE_LIST_SUCCESS;

    constructor(public payload: MovieList) { }
}

export class UpdateMovieListFailure implements Action {
    readonly type = UPDATE_MOVIE_LIST_FAILURE;

    constructor(public payload: any) { }
}

export const ADD_MOVIE_TO_MOVIE_LIST = '[MovieList] Add Movie to Movie List';
export const ADD_MOVIE_TO_MOVIE_LIST_SUCCESS = '[MovieList] Add Movie to Movie List Success';
export const ADD_MOVIE_TO_MOVIE_LIST_FAILURE = '[MovieList] Add Movie to Movie List Failure';

export interface AddMovieToMovieListPayload {
    Id: string,
    Movie: Movie
}

export class AddMovieToMovieList implements Action {
    readonly type = ADD_MOVIE_TO_MOVIE_LIST;

    constructor(public payload: AddMovieToMovieListPayload) { }
}

export class AddMovieToMovieListSuccess implements Action {
    readonly type = ADD_MOVIE_TO_MOVIE_LIST_SUCCESS;

    constructor(public payload: MovieList) { }
}

export class AddMovieToMovieListFailure implements Action {
    readonly type = ADD_MOVIE_TO_MOVIE_LIST_FAILURE;

    constructor(public payload: any) { }
}

export const REMOVE_MOVIE_FROM_MOVIE_LIST = '[MovieList] Remove Movie from Movie List';
export const REMOVE_MOVIE_FROM_MOVIE_LIST_SUCCESS = '[MovieList] Remove Movie from Movie List Success';
export const REMOVE_MOVIE_FROM_MOVIE_LIST_FAILURE = '[MovieList] Remove Movie from Movie List Failure';

export interface RemoveMovieFromMovieListPayload {
    Id: string,
    Movie: Movie
}

export class RemoveMovieFromMovieList implements Action {
    readonly type = REMOVE_MOVIE_FROM_MOVIE_LIST;

    constructor(public payload: RemoveMovieFromMovieListPayload) { }
}

export class RemoveMovieFromMovieListSuccess implements Action {
    readonly type = REMOVE_MOVIE_FROM_MOVIE_LIST_SUCCESS;

    constructor(public payload: MovieList) { }
}

export class RemoveMovieFromMovieListFailure implements Action {
    readonly type = REMOVE_MOVIE_FROM_MOVIE_LIST_FAILURE;

    constructor(public payload: any) { }
}

export type Actions =
    | CreateMovieList
    | CreateMovieListSuccess
    | CreateMovieListFailure
    ////
    | GetAllMovieLists
    | GetAllMovieListsSuccess
    | GetAllMovieListsFailure
    ////
    | GetSingleMovieList
    | GetSingleMovieListSuccess
    | GetSingleMovieListFailure
    ////
    | DeleteMovieList
    | DeleteMovieListSuccess
    | DeleteMovieListFailure
    ////
    | UpdateMovieList
    | UpdateMovieListSuccess
    | UpdateMovieListFailure
    ////
    | AddMovieToMovieList
    | AddMovieToMovieListSuccess
    | AddMovieToMovieListFailure
    ////
    | RemoveMovieFromMovieList
    | RemoveMovieFromMovieListSuccess
    | RemoveMovieFromMovieListFailure;