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

import * as restaurantActions from '../actions/restaurant.actions';
import { Observable } from "rxjs/Observable";
import { City } from "../../models/city";
import { RestaurantService } from "../../services/restaurant.service";
import { List } from "immutable";
import { Restaurant } from "../../models/restaurant";


@Injectable()
export class RestaurantEffects {
    @Effect()
    loadCities$: Observable<Action> = this.actions$.ofType(restaurantActions.LOAD_CITIES)
        .switchMap(() => this
            .restaurantService
            .LoadCities()
            .map((cities: Array<City>) => new restaurantActions.LoadCitiesSuccess(cities))
            .catch((error: any) => of(new restaurantActions.LoadCitiesFailure(error))));

    @Effect()
    loadRestaurants$: Observable<Action> = this.actions$.ofType(restaurantActions.LOAD_RESTAURANTS)
        .map(toPayload)
        .switchMap((city) => this
            .restaurantService
            .LoadRestaurants(city)
            .map((restaurants: List<Restaurant>) => new restaurantActions.LoadRestaurantsSuccess(restaurants))
            .catch((error: any) => of(new restaurantActions.LoadRestaurantsFailure(error))));

    constructor(
        private actions$: Actions,
        private router: Router,
        private restaurantService: RestaurantService
    ) { }
}