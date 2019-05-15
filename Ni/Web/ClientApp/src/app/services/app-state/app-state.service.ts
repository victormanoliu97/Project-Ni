import { Injectable } from '@angular/core';
import {AuthResponse} from '../../models/auth/authResponse';
import {AuthService} from '../auth/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AppStateService {

  auth: AuthResponse;

  constructor(public authService: AuthService) {
    this.authService = authService;
  }
}
