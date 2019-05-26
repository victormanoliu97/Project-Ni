import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {LoginComponent} from './login/login.component';
import {FormsModule} from '@angular/forms';
import {RegisterComponent} from './register/register.component';

@NgModule({
    imports: [
        CommonModule,
        FormsModule
    ],
    declarations: [LoginComponent, RegisterComponent],
    exports: [LoginComponent]
})
export class AuthModule {
}
