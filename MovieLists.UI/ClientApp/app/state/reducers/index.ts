﻿import {
    ActionReducerMap,
    createSelector,
    createFeatureSelector,
    ActionReducer,
    MetaReducer,
} from '@ngrx/store';
import { environment } from '../../environments/environment';
import { RouterStateUrl } from '../../shared/utils';
import * as fromRouter from '@ngrx/router-store';

/**
 * Every reducer module's default export is the reducer function itself. In
 * addition, each module should export a type or interface that describes
 * the state of the reducer plus any selector functions. The `* as`
 * notation packages up all of the exports into a single object.
 */
// TODO: make layout reducer for menu and other layout specific things that need state 
//import * as fromLayout from '../core/reducers/layout';
import * as fromReviews from './reviews/review.reducer';
import * as fromRestaurants from './restaurants/restaurant.reducer';

/**
 * As mentioned, we treat each reducer like a table in a database. This means
 * our top level state interface is just a map of keys to inner state types.
 */
//TODO make layout reducer for menu and other layout specific things that need state 
export interface State {
    //layout: fromLayout.State;
    reviews: fromReviews.State,
    restaurants: fromRestaurants.State
}

/**
 * Our state is composed of a map of action reducer functions.
 * These reducer functions are called with each dispatched action
 * and the current or initial state and return a new immutable state.
 */
//TODO make layout reducer for menu and other layout specific things that need state 
export const reducers: ActionReducerMap<State> = {
    //layout: fromLayout.reducer,
    reviews: fromReviews.reducer,
    restaurants: fromRestaurants.reducer
};

// console.log all actions
export function logger(reducer: ActionReducer<State>) {
    return function (state: State, action: any) {
        console.log('state', state);
        console.log('action', action);

        return reducer(state, action);
    };
}

/**
 * By default, @ngrx/store uses combineReducers with the reducer map to compose
 * the root meta-reducer. To add more meta-reducers, provide an array of meta-reducers
 * that will be composed to form the root meta-reducer.
 */
export const metaReducers: MetaReducer<State>[] = !environment.production
    ? [logger]
    : [];


// TODO: make layout reducer for menu and other layout specific things that need state 
/**
 * Layout Reducers
 */
//export const getLayoutState = createFeatureSelector<fromLayout.State>('layout');

//export const getShowSidenav = createSelector(
//    getLayoutState,
//    fromLayout.getShowSidenav
//);


export const getReviewState = (state: State) => state.reviews;
export const getCurrentReviews = createSelector(getReviewState, fromReviews.getCurrentReviews);

export const getRestaurantState = (state: State) => state.restaurants;
export const getCities = createSelector(getRestaurantState, fromRestaurants.getCities);
export const getRestaurants = createSelector(getRestaurantState, fromRestaurants.getRestaurants);