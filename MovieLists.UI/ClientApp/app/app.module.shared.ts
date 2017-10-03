import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { ButtonsModule } from '@progress/kendo-angular-buttons';
import { GridModule } from '@progress/kendo-angular-grid';
import { environment } from './environments/environment';
import { CustomRouterStateSerializer } from './shared/utils';
import { StoreRouterConnectingModule, RouterStateSerializer, } from '@ngrx/router-store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { reducers, metaReducers } from './state/reducers';
import { ReviewEffects } from "./state/effects/review.effects";
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';
import { ConnectFormDirective } from "./shared/connect-form.directive";
import { RestaurantEffects } from "./state/effects/restaurant.effects";
import { RestaurantService } from "./services/restaurant.service";
import { ReviewService } from "./services/review.service";

@NgModule({
    declarations: [
        //
        //
        //main app
        AppComponent,
        NavMenuComponent,
        //
        //
        //custom components
        ConnectFormDirective
    ],
    imports: [
        //
        //
        //angular
        CommonModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        //
        //
        //routes
        RouterModule.forRoot([
            { path: '', redirectTo: 'reviews', pathMatch: 'full' },
            { path: 'reviews', loadChildren: './components/reviews/reviews.module#ReviewsModule' },
            { path: 'add-a-review', loadChildren: './components/add-a-review/add-a-review.module#AddAReviewModule' }
        ]),
        //
        //
        //kendo
        ButtonsModule,
        GridModule,
        DropDownsModule,
        DateInputsModule,
        //
        //
        //ngrx
        StoreModule.forRoot(reducers, { metaReducers }),
        StoreRouterConnectingModule,
        !environment.production ? StoreDevtoolsModule.instrument() : [],
        EffectsModule.forRoot([
            ReviewEffects,
            RestaurantEffects
        ])
    ],
    providers: [
        { provide: RouterStateSerializer, useClass: CustomRouterStateSerializer },
        RatingsService,
        OmdbService,
        MovieListService
    ]
})
export class AppModuleShared {
}
