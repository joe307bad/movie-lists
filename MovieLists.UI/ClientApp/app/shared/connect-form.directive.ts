import { Directive, EventEmitter, Input, Output, OnInit } from '@angular/core';
import { FormGroupDirective } from '@angular/forms';
import { Store } from '@ngrx/store';
import { Subscription } from 'rxjs/Subscription';
import { Actions } from '@ngrx/effects';
import * as fromRoot from '../state/reducers';

@Directive({
    selector: '[connectForm]'
})
export class ConnectFormDirective implements OnInit {
    @Input('connectForm') path: string;
    @Input() debounce: number = 300;
    formChange: Subscription;

    constructor(private formGroupDirective: FormGroupDirective, private store: Store<fromRoot.State>) {

    }

    ngOnInit() {

        this.formChange = this.formGroupDirective.form.valueChanges
            .debounceTime(this.debounce).subscribe(value => {

                console.log(value);
            });
    }


}