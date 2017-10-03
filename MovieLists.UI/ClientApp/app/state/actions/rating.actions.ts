import { Action } from '@ngrx/store';
import { List } from "immutable";
import { MovieList } from "../../models/movie-list";
import { Movie } from "../../models/movie";
import { Rating } from "../../models/rating";

export const CREATE_RATING = '[Rating] Create Rating';
export const CREATE_RATING_SUCCESS = '[Rating] Create Rating Success';
export const CREATE_RATING_FAILURE = '[Rating] Create Rating Failure';

export class CreateRating implements Action {
    readonly type = CREATE_RATING;

    constructor(public payload: Rating) { }
}

export class CreateRatingSuccess implements Action {
    readonly type = CREATE_RATING_SUCCESS;

    constructor(public payload: Rating) { }
}

export class CreateRatingFailure implements Action {
    readonly type = CREATE_RATING_FAILURE;

    constructor(public payload: any) { }
}

export const UPDATE_RATING = '[Rating] Update Movie';
export const UPDATE_RATING_SUCCESS = '[Rating] Update Movie Success';
export const UPDATE_RATING_FAILURE = '[Rating] Update Movie Failure';

export interface UpdateRatingPayload {
    Id: string;
    Rating: Rating;
}

export class UpdateRating implements Action {
    readonly type = UPDATE_RATING;

    constructor(public payload: UpdateRatingPayload) { }
}

export class UpdateRatingdSuccess implements Action {
    readonly type = UPDATE_RATING_SUCCESS;

    constructor(public payload: Rating) { }
}

export class UpdateRatingFailure implements Action {
    readonly type = UPDATE_RATING_FAILURE;

    constructor(public payload: any) { }
}

export type Actions =
    | CreateRating
    | CreateRatingSuccess
    | CreateRatingFailure
    ////
    | UpdateRating
    | UpdateRatingdSuccess
    | UpdateRatingFailure;