import { createSelector, createFeatureSelector } from '@ngrx/store';
import * as restaurantActions from '../../actions/restaurant.actions';
import { List } from "immutable";
import { City } from "../../../models/city";
import { Restaurant } from "../../../models/restaurant";

export interface State {
    cities: Array<City>;
    restaurants: List<Restaurant>;
}

export const initialState: State = {
    cities: [],
    restaurants: List([])
};

export function reducer(state = initialState, action: restaurantActions.Actions): State {
    switch (action.type) {

        case restaurantActions.LOAD_CITIES: {
            return state;
        }

        case restaurantActions.LOAD_CITIES_SUCCESS: {
            return {
                ...state,
                cities: action.payload
            };
        }

        case restaurantActions.LOAD_CITIES_FAILURE: {
            return state;
        }

        case restaurantActions.LOAD_RESTAURANTS: {
            return state;
        }

        case restaurantActions.LOAD_RESTAURANTS_SUCCESS: {
            return {
                ...state,
                restaurants: action.payload
            };
        }

        case restaurantActions.LOAD_RESTAURANTS_FAILURE: {
            return state;
        }

        default: {
            return state;
        }
    }
}

export const getCities = (state: State) => state.cities;
export const getRestaurants = (state: State) => state.restaurants;