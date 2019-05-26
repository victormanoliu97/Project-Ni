import {Component, OnInit} from '@angular/core';
import {AuthService} from '../../services/auth/auth.service';
import {Router} from '@angular/router';
import {AuthResponse} from '../../models/auth/authResponse';
import {AppStateService} from '../../services/app-state/app-state.service';
import {CookieService} from 'ngx-cookie-service';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

    authResponse: AuthResponse;
    userName: string;
    password: string;


    constructor(private authService: AuthService, private router: Router,
                public stateService: AppStateService) {
    }

    ngOnInit() {
    }

    async getLogin(userName: string, password: string) {
        this.authResponse = await this.authService.login(userName, password);
        if (this.authResponse != null) {
            this.stateService.auth = this.authResponse;
            this.stateService.setCookie('userId', String(this.stateService.auth.userId));
            this.stateService.setCookie('authKey', this.stateService.auth.authKey);
            console.log(this.stateService.auth);
            this.router.navigate(['panel']);
        }
    }

}
