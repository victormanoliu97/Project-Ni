import {Component, OnInit} from '@angular/core';
import {GenericResponse} from '../../models/genericResponse';
import {AuthService} from '../../services/auth/auth.service';
import {Router} from '@angular/router';

@Component({
    selector: 'app-register',
    templateUrl: './register.component.html',
    styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

    registerResponse: GenericResponse;
    userName: string;
    password: string;
    email: string;

    constructor(private authService: AuthService, private router: Router) {
    }

    ngOnInit() {
    }

    async registerUser(email: string, userName: string, password: string) {
        this.registerResponse = await this.authService.register(email, userName, password);
        if (this.registerResponse.statusCode === 200) {
            this.router.navigate(['login']);
        }
    }
}
