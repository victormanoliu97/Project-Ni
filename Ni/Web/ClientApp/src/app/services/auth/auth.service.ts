import {Injectable} from '@angular/core';
import {ServerService} from '../server/server.service';
import {AuthRequest, RegisterRequest} from '../../models/auth/authRequest';
import {AuthResponse} from '../../models/auth/authResponse';
import {HttpClient} from '@angular/common/http';
import {GenericResponse} from '../../models/genericResponse';

@Injectable({
    providedIn: 'root'
})
export class AuthService {

    registerUrl = 'api/accounts';
    loginUrl = 'Auth';

    constructor(public serverService: ServerService,
                public http: HttpClient) {
        this.serverService = serverService;
        this.http = http;
    }

    async login(email: string, password: string) {
        const request = new AuthRequest();
        request.email = email;
        request.password = password;

        return this.http.get<AuthResponse>(this.serverService.mainServerUrl + this.loginUrl, {
            params: request as any,
            headers: this.serverService.requestHeaders
        }).toPromise();
    }

    async register(email: string, username: string, password: string) {
        const request = new RegisterRequest();
        request.email = email;
        request.username = username;
        request.password = password;
        return this.http.post<GenericResponse>(this.serverService.mainServerUrl + this.registerUrl, request,
            {headers: this.serverService.requestHeaders}).toPromise();
    }
}
